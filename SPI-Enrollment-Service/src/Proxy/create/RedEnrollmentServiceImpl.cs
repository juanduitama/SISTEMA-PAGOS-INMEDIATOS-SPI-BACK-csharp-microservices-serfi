
using System.Text;
using System.Text.Json;
using application.interfaces;
using application.mapper;
using application.util;
using application.Util;
using domain.constants;
using domain.models.oAuth;
using domain.models.redeban;
using domain.models.redeban.response;
using Nest;
using Util.util;


namespace application.Services.create
{
    public class RedEnrollmentServiceImpl : IRedEnrollmentService
    {
        /// <summary>
        /// Cliente HTTP estático compartido para todas las instancias del servicio.
        /// </summary>
        private  readonly HttpClient _httpClient;
        /// <summary>
        /// Utilidad para construir y configurar instancias de HttpClient.
        /// </summary>
        private  readonly BuilderHttpUtil _BuilderHttpUtil;

        private readonly RedRqMapper redMapper;
        private readonly IOauthServices _oauthService = new OAuthService();



        ///// <summary>
        ///// Constructor estático que inicializa los recursos compartidos.
        ///// Configura el cliente HTTP una sola vez para su reutilización en todas las solicitudes.
        //// </summary>
        public RedEnrollmentServiceImpl()
        {
            _BuilderHttpUtil = new BuilderHttpUtil();
            //_httpClient = _BuilderHttpUtil.BuildClient();
            _httpClient = _BuilderHttpUtil.BuildClientWithServerCertificate();
            redMapper = new RedRqMapper();
        }



        /// <summary>
        /// Realiza una operación de creación (POST) a la API Red utilizando la URL, cabeceras y datos proporcionados.
        /// </summary>
        /// <param name="url">URL completa del endpoint al que se enviará la petición.</param>
        /// <param name="headers">Objeto que contiene las cabeceras HTTP requeridas para la petición.</param>
        /// <param name="requestBody">Objeto que contiene los datos a enviar en el cuerpo de la solicitud.</param>
        /// <returns>Objeto HttpResponseMessage que contiene la respuesta del servidor.</returns>
        /// <exception cref="HttpRequestException">
        /// Se lanza cuando ocurre un error en la comunicación HTTP con el servidor.
        /// </exception>
        /// <exception cref="JsonException">
        /// Se lanza cuando hay un error al procesar datos JSON recibidos o enviados.
        /// </exception>
        /// <exception cref="Exception">
        /// Se lanza para cualquier otro error inesperado durante el proceso de creación.   
        /// </exception>
        public async Task<MsgInformationResponse> Create(string url, HeadersRq headers, EnrollmentRqRed requestBody)
        {
            try
            {

                MsgInformationResponse responseRedeban = new MsgInformationResponse();

                Console.WriteLine($"[INFO] Iniciando solicitud POST a: {url}");

                ClearHeaders();

                RsOAuth responseOauth = await _oauthService.getToken(ConstantsEnum.BASE_URI_OAUTH, _httpClient);

                Console.WriteLine("Token obtenido Oauth: " + responseOauth.accessToken);

                ClearHeaders();
                // Agregar cabeceras HTTP necesarias
                redMapper.AddCreateHeaders(_httpClient, headers, responseOauth.accessToken);

                string jsonContent = await UtilCommons.Object2String(requestBody);

                Console.WriteLine($"[DEBUG] Body a enviar: {jsonContent}");

                // Crear el contenido para la solicitud HTTP
                var content = new StringContent(jsonContent, Encoding.UTF8, ConstantsEnum.APPLICATION_JSON);

                string contentBody = await content.ReadAsStringAsync();

                // Realizar la solicitud POST
                Console.WriteLine("[INFO] Enviando solicitud POST...");

                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

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
