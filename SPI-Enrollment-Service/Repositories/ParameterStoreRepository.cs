using Amazon.SimpleSystemsManagement.Model;
using Amazon.SimpleSystemsManagement;

namespace Repositories
{
    public class ParameterStoreRepository
    {
        private readonly IAmazonSimpleSystemsManagement _ssm;

        public ParameterStoreRepository(IAmazonSimpleSystemsManagement ssm)
        {
            _ssm = ssm;
        }

        public async Task<string> GetOpenSearchUriAsync(string parameterName)
        {
            var response = await _ssm.GetParameterAsync(new GetParameterRequest
            {
                Name = parameterName,
                WithDecryption = true
            });

            return response.Parameter.Value;
        }
    }
}
