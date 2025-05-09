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


        public async Task <OSDefinitive> SearchKeyByKeyValue(string keyValue)
        {
            try
            {
                Console.WriteLine($"Buscando llaves con valor {keyValue}");

                var searchResponse = await _client.SearchAsync<OSDefinitive>(s => s
                    .Index(_indexName)
                    .Query(q => q
                        .Bool(b => b
                            .Must(
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

        public async Task <OSDefinitive> SearchKeyByIdent(string custIdentType, string custIdentNumber)
        {
            try
            {
                Console.WriteLine($"Buscando llaves con tipo de identificación {custIdentType} y número de identificación {custIdentNumber}");

                var searchResponse = await _client.SearchAsync<OSDefinitive>(s => s
                    .Index(_indexName)
                    .Query(q => q
                        .Bool(b => b
                            .Must(
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
    }
       
}
