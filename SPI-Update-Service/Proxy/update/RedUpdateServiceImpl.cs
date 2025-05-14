
using System.Text;

using System.Text.Json;
using domain.models.redeban;

using SPI_Update_Service.domain.models.redeban;
using domain.constants;
using domain.models.redeban.response;
using domain.models.oAuth;

using SPI_Update_Service.Proxy.interfaces;
using SPI_Update_Service.Utils.util;
using SPI_Update_Service.Utils.mapper;

namespace SPI_Update_Service.Proxy.update
{
    public class RedUpdateServiceImpl : IRedUpdateService
    {
        /// <summary>
        /// Cliente HTTP estático compartido para todas las instancias del servicio.
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Utilidad para construir y configurar instancias de HttpClient.
        /// </summary>
        private readonly BuilderHttpUtil _BuilderHttpUtil;

        private readonly JsonSerializerOptions _jsonOptions;
        private readonly RedRqMapper redMapper;

        private readonly IOauthServices _oauthService = new OAuthService();

        /// <summary>
        /// Constructor estático que inicializa los recursos compartidos.
        /// Configura el cliente HTTP una sola vez para su reutilización en todas las solicitudes.
        /// </summary>
        public RedUpdateServiceImpl()
        {
            _BuilderHttpUtil = new BuilderHttpUtil();
            _httpClient = _BuilderHttpUtil.BuildClientWithServerCertificate();

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            redMapper = new RedRqMapper();

        }

        public async Task<MsgInformationResponse> UpdateAccountAsync(string url, HeadersRq headers, UpdateAcctRq requestBody)
        {
            try
            {

                MsgInformationResponse responseRedeban = new MsgInformationResponse();

                ClearHeaders();

                RsOAuth responseOauth = await _oauthService.getToken(ConstantsEnum.BASE_URI_OAUTH, _httpClient);

                Console.WriteLine("Token obtenido Oauth: " + responseOauth.accessToken);

                Console.WriteLine($"[INFO] Iniciando solicitud PATCH Update account a: {url}");
                ClearHeaders();

                redMapper.AddUpdateHeaders(_httpClient, headers, responseOauth.accessToken);

                string jsonContent = await UtilCommons.Object2String(requestBody);

                Console.WriteLine($"[DEBUG] body a enviar: {jsonContent}");

                var content = new StringContent(jsonContent, Encoding.UTF8, ConstantsEnum.APPLICATION_JSON);

                string contentBody = await content.ReadAsStringAsync();

                Console.WriteLine("[INFO] Enviando solicitud PATCH...");

                HttpResponseMessage response = await _httpClient.PatchAsync(url, content);

                string responseRes = await response.Content.ReadAsStringAsync();

                responseRedeban = await UtilCommons.String2Object<MsgInformationResponse>(responseRes);

                Console.WriteLine($"[RES] Respuesta: {responseRes}");

                return responseRedeban;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"[ERROR] Error de solicitud HTTP: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"[ERROR] Inner Exception: {ex.InnerException.Message}");
                }
                throw; // Re-lanzamos la excepción para que la función Lambda la maneje
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"[ERROR] Error al procesar JSON: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Error inesperado: {ex.Message}");
                Console.WriteLine($"[ERROR] Stack Trace: {ex.StackTrace}");
                throw;
            }
            throw new NotImplementedException();
        }
        /// <summary>
        /// Limpia todas las cabeceras HTTP predeterminadas del cliente HTTP.
        /// </summary>
        /// <remarks>
        /// Este método se utiliza para evitar la acumulación de cabeceras duplicadas
        /// entre llamadas consecutivas utilizando el mismo cliente HTTP.
        /// </remarks>
        private void ClearHeaders()
        {
            _httpClient.DefaultRequestHeaders.Clear();
        }
    }
}
