using Models.enrollment;
using Models.openSearchModel;
using Nest;
using OpenSearch.Client;
using SPI_directory_service.Controllers;
using SPI_Enrollment_Service.service.create;
using SPI_Enrollment_Serviceconstants;

namespace Services
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

                var results = new OSDefinitive();

                Console.WriteLine($"Se encontraron {results} registros");

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

                Console.WriteLine("Se guardo exitosamente el cliente en open search");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar llave: {ex.Message}");
                throw new ApplicationException("Error al buscar llave en OpenSearch", ex);
            }
        }
    }
}
