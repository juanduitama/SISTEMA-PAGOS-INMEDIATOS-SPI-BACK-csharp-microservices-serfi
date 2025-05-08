using application.interfaces;
using application.util;
using domain.constants;
using domain.models.openSearchModel;
using OpenSearch.Client;

namespace application.Services
{
    public class OpenSearchService : IOpenSearchService
    {
        private readonly IOpenSearchClient _client;
        private readonly string _indexName;


        public async Task <OSDefinitive> SearchKey(string keyType, string keyValue)
        {
            try
            {
                Console.WriteLine($"Buscando llaves de tipo {keyType} con valor {keyValue}");

                var searchResponse = await _client.SearchAsync<OSDefinitive>(s => s
                    .Index(_indexName)
                    .Query(q => q
                        .Bool(b => b
                            .Must(
                                m => m.Term(t => t.Field("key.keyType").Value(keyType)),
                                m => m.Term(t => t.Field("key.keyValue").Value(keyValue))
                            )
                        )
                    )
                    .Size(10)
                );

                if (!searchResponse.IsValid)
                {
                    Console.WriteLine($"Error en la búsqueda: {searchResponse.ServerError?.Error?.Reason}");
                    return new OSDefinitive();
                }

                string resultString = await UtilCommons.Object2String(searchResponse);
                Console.WriteLine($"Se encontraron el siguiente registro: " + resultString );

                OSDefinitive results = await UtilCommons.String2Object<OSDefinitive>(resultString);

                Console.WriteLine($"El objeto OSDefinitive es: " + results);

                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar llave: {ex.Message}");
                throw new ApplicationException("Error al buscar llave en OpenSearch", ex);
            }
        }

        public async Task SaveKey(OSDefinitive osDefinitive)
        {
            try
            {
                Console.WriteLine($"Buscando llaves de tipo {osDefinitive.key.keyType} con valor {osDefinitive.key.keyId}");

                var createResponse = await _client.Indices.CreateAsync(ConstantsEnum.INDEX_DEFINITIVE,
                c => c.Map(m => m.AutoMap<OSDefinitive>()));

                Console.WriteLine("Se guardo exitosamente la llave en open search");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar llave: {ex.Message}");
                throw new ApplicationException("Error al buscar llave en OpenSearch", ex);
            }
        }

        public async Task DeleteKey(string keyType, string keyValue)
        {
            try
            {
                Console.WriteLine($"Eliminando llave: Tipo={keyType}, Valor={keyValue}");

                // Primero buscamos el documento por su tipo y valor de llave
                var searchResponse = await _client.SearchAsync<OSDefinitive>(s => s
                    .Index(_indexName)
                    .Query(q => q
                        .Bool(b => b
                            .Must(
                                m => m.Term(t => t.Field("key.keyType").Value(keyType)),
                                m => m.Term(t => t.Field("key.keyValue").Value(keyValue)),
                                m => m.Term(t => t.Field("key.keyStatus").Value(ValidationEnums.KEY_ACTIVE_STATUS))
        
                            )
                        )
                    )
                    .Size(1)
                );

                if (!searchResponse.IsValid || searchResponse.Hits.Count == 0)
                {
                    Console.WriteLine($"No se encontró la llave para eliminar: Tipo={keyType}, Valor={keyValue}");
                }

                // Obtenemos el ID del documento encontrado
                string documentId = searchResponse.Hits.FirstOrDefault()?.Id;

                // Eliminamos el documento usando su ID
                var deleteResponse = await _client.DeleteAsync<OSDefinitive>(documentId, d => d
                    .Index(_indexName)
                );

                if (!deleteResponse.IsValid)
                {
                    Console.WriteLine($"Error al eliminar documento: {deleteResponse.DebugInformation}");
                }

                Console.WriteLine($"Llave eliminada correctamente: Tipo={keyType}, Valor={keyValue}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar llave: {ex.Message}");
                throw new ApplicationException("Error al eliminar llave en OpenSearch", ex);
            }
        }
    }
}
