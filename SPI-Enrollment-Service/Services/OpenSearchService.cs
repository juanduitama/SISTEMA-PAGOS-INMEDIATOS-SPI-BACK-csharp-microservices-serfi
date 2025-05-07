using Models.enrollment;
using Models.openSearchModel;
using Nest;
using OpenSearch.Client;
using SPI_Enrollment_Serviceconstants;

namespace Services
{
    public class OpenSearchService : IOpenSearchService
    {
        private readonly ILogger<OpenSearchService> _logger;
        private readonly IOpenSearchClient _client;
        private readonly string _indexName;

        public async Task <OSDefinitive> SearchKey(string keyType, string keyValue)
        {
            try
            {
                _logger.LogInformation($"Buscando llaves de tipo {keyType} con valor {keyValue}");

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
                    _logger.LogWarning($"Error en la búsqueda: {searchResponse.ServerError?.Error?.Reason}");
                    return new OSDefinitive();
                }

                var results = new OSDefinitive();

                _logger.LogInformation($"Se encontraron {results} registros");

                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al buscar llave: {ex.Message}");
                throw new ApplicationException("Error al buscar llave en OpenSearch", ex);
            }
        }

        public async Task SaveKey(OSDefinitive osDefinitive)
        {
            try
            {
                _logger.LogInformation($"Buscando llaves de tipo {osDefinitive.key.keyType} con valor {osDefinitive.key.keyId}");

                var createResponse = await _client.Indices.CreateAsync(ConstantsEnum.INDEX_DEFINITIVE,
                c => c.Map(m => m.AutoMap<OSDefinitive>()));

                _logger.LogInformation("Se guardo exitosamente el cliente en open search");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al buscar llave: {ex.Message}");
                throw new ApplicationException("Error al buscar llave en OpenSearch", ex);
            }
        }
    }
}
