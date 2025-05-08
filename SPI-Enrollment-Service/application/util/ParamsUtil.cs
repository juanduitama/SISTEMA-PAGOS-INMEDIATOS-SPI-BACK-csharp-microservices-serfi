using System.Text.Json;
using domain.models;
using infrastructure.repositories;
using OpenSearch.Client;

namespace application.util
{
    public class ParamsUtil
    {
        private readonly SecretManagerRepository _secretManagerRepository;
        private readonly ParameterStoreRepository _parameterStoreRepository;

        public ParamsUtil(SecretManagerRepository secretManagerRepository, ParameterStoreRepository parameterStoreRepository)
        {
            _secretManagerRepository = secretManagerRepository;
            _parameterStoreRepository = parameterStoreRepository;
        }

        public IConnectionSettingsValues buildSettings()
        {
            var uri = _parameterStoreRepository.GetOpenSearchUriAsync("/opensearch/uri").Result;
            var credsJson = _secretManagerRepository.GetSecretAsync("opensearch/credentials").Result;
            var creds = JsonSerializer.Deserialize<OpenSearchCredentials>(credsJson);
            var settings = new ConnectionSettings(new Uri(uri))
                .BasicAuthentication(creds.Username, creds.Password);
            return settings;

        }
    }
}
