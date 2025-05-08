using System.Text.Json;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace infrastructure.repositories
{
    public class SecretManagerRepository
    {
        private readonly IAmazonSecretsManager _secretsManager;

        public SecretManagerRepository(IAmazonSecretsManager secretsManager)
        {
            _secretsManager = secretsManager;
        }

        public async Task<string> GetSecretAsync(string secretName)
        {
            var request = new GetSecretValueRequest { SecretId = secretName };
            var response = await _secretsManager.GetSecretValueAsync(request);
            return response.SecretString;
        }
    }
}
