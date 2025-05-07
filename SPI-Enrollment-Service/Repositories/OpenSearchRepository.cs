using OpenSearch.Client;
using OpenSearch.Net;

namespace SPI_Enrollment_Service.Repositories
{
    public class OpenSearchClientRepository
    {
        public IOpenSearchClient Client { get; }

        public OpenSearchClientRepository(string uri, string username, string password, string defaultIndex)
        {
            var settings = new ConnectionSettings(new Uri(uri))
                .BasicAuthentication(username, password)
                .ServerCertificateValidationCallback(CertificateValidations.AllowAll)
                .DefaultIndex(defaultIndex);

            Client = new OpenSearchClient(settings);
        }
    }
}
