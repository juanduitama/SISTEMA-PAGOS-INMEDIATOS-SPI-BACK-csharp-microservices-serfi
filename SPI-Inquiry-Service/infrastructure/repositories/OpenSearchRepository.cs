using domain.constants;
using OpenSearch.Client;
using OpenSearch.Net;

namespace infrastructure.repositories
{
    public class OpenSearchClientRepository
    {
        public IOpenSearchClient Client { get; }

        public OpenSearchClientRepository(string uri, string username, string password, string defaultIndex)
        {
            try{
            var settings = new ConnectionSettings(new Uri(uri))
                .BasicAuthentication(username, password)
                .ServerCertificateValidationCallback(CertificateValidations.AllowAll)
                .DefaultIndex(defaultIndex);

            Client = new OpenSearchClient(settings);
            }catch(Exception ex){
                Console.WriteLine($"Error al conextar con open search: {ex.Message}");
                throw new SerfiException(ResponseServiceEnum.CONNECTION_OS.getErrorCode(), ResponseServiceEnum.CONNECTION_OS.getMessage(), ResponseServiceEnum.CONNECTION_OS.getHttpCode());
            }
        }
    }
}
