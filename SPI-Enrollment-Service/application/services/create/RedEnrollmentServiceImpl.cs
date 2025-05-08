using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using application.interfaces;
using application.mapper;
using application.util;
using application.Util;
using domain.constants;
using domain.models.redeban;
using domain.models.redeban.response;


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
        /// <summary>
        /// Constructor estático que inicializa los recursos compartidos.
        /// Configura el cliente HTTP una sola vez para su reutilización en todas las solicitudes.
        /// </summary>
        public RedEnrollmentServiceImpl()
        {
            _BuilderHttpUtil = new BuilderHttpUtil();
            _httpClient = _BuilderHttpUtil.BuildClient();
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
        public async Task<MessageInformation> Create(string url, HeadersRq headers, EnrollmentRqRed requestBody)
        {
            try
            {

                MessageInformation responseRedeban = new MessageInformation();

                Console.WriteLine($"[INFO] Iniciando solicitud POST a: {url}");

                ClearHeaders();

                // Agregar cabeceras HTTP necesarias
                redMapper.AddCreateHeaders(_httpClient, headers);

                // Configurar cabeceras adicionales específicas para POST
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ConstantsEnum.APPLICATION_JSON);
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", ConstantsEnum.APPLICATION_JSON);

                string jsonContent = await UtilCommons.Object2String(requestBody);

                Console.WriteLine($"[DEBUG] JSON a enviar: {jsonContent}");

                // Crear el contenido para la solicitud HTTP
                var content = new StringContent(jsonContent, Encoding.UTF8, ConstantsEnum.APPLICATION_JSON);

                string contentBody = await content.ReadAsStringAsync();
                Console.WriteLine("El json del content body:" + contentBody);

                // Realizar la solicitud POST
                Console.WriteLine("[INFO] Enviando solicitud POST...");

                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                
                Console.WriteLine($"[INFO] Respuesta recibida con código: {response.StatusCode}");

                string responseRes = await response.Content.ReadAsStringAsync();

                // JsonSerializer.Deserialize<MessageInformation>(responseRes);
                responseRedeban = await UtilCommons.String2Object<MessageInformation>(responseRes);
                
                Console.WriteLine($"[RES] Respuesta: {responseRedeban.ToString()}");
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
