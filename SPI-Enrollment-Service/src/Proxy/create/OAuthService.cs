

using application.interfaces;
using application.mapper;
using application.util;
using application.Util;
using domain.constants;
using domain.models.oAuth;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace application.Services
{
    public class OAuthService : IOauthServices
    {

        private readonly RedRqMapper redMapper = new RedRqMapper();


        public OAuthService()
        {

        }



        public async Task<bool> validateToken(string token)
        {
            return false;
        }

        public async Task<RsOAuth> getToken(string url, HttpClient _httpClient)
        {

            
            Console.WriteLine($"Comienza obtención de token \n url: {url}");
            
            _httpClient.DefaultRequestHeaders.Clear();
            // Agregar cabeceras HTTP necesarias
            redMapper.addOauthHeaders(_httpClient);
            RqOAuth rqOauth = redMapper.mapBodyOauth();

            RsOAuth responseOAuth = new RsOAuth();

            // CAMBIO: En lugar de JSON, crear URL-encoded form data
            var formData = ConvertToFormData(rqOauth);
            var content = new FormUrlEncodedContent(formData);

            // Asegurarse de que el Content-Type es correcto
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(ConstantsEnum.APPLICATION_URL_ENCODE);

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            string responseRes = await response.Content.ReadAsStringAsync();

            responseOAuth = await UtilCommons.String2Object<RsOAuth>(responseRes);

            string responseOAuthS = await UtilCommons.Object2String(responseRes);

            Console.WriteLine($"[RES] Respuesta:" + responseOAuthS);

            return responseOAuth;
        }



        private Dictionary<string, string> ConvertToFormData(RqOAuth rqOAuth)
        {
            var formData = new Dictionary<string, string>();

            if (rqOAuth != null)
            {
                formData.Add("grant_type", "client_credentials"); 

                formData.Add("data", JsonSerializer.Serialize(rqOAuth));

            }

            return formData;
        }

    }
    }
