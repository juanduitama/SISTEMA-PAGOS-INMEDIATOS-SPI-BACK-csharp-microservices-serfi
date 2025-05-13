using domain.models.oAuth;

namespace application.interfaces
{
    public interface IOauthServices
    {
        Task<bool> validateToken(string token);

        Task<RsOAuth> getToken(string url, HttpClient _httpClient);
    }
}
