using domain.models.oAuth;

namespace SPI_Update_Service.Proxy.interfaces
{
    public interface IOauthServices
    {
        Task<bool> validateToken(string token);

        Task<RsOAuth> getToken(string url, HttpClient _httpClient);
    }
}
