using Services.inquiry;
using SPI_Inquiry_Service.Util;
using SPI_lambda_consulta.model;
using SPI_lambda_consulta.util;
using System.Text.Json;

namespace SPI_Inquiry_Service.Services.inquiry
{
    /// <summary>
    /// Implementación concreta del servicio de consulta a la API Red.
    /// Maneja las solicitudes HTTP y procesa las respuestas utilizando un cliente HTTP preconfigurado.
    /// </summary>
    public class RedInquiryServiceImpl : IRedInquiryService
    {

        /// <summary>
        /// Cliente HTTP estático compartido para todas las instancias del servicio.
        /// </summary>
        private static readonly HttpClient _httpClient;

        /// <summary>
        /// Utilidad para construir y configurar instancias de HttpClient.
        /// </summary>
        private static readonly BuilderHttpUtil _BuilderHttpUtil;

        /// <summary>
        /// Constructor estático que inicializa los recursos compartidos.
        /// Configura el cliente HTTP una sola vez para su reutilización en todas las solicitudes.
        /// </summary>
        static RedInquiryServiceImpl()
        {
            _BuilderHttpUtil = new BuilderHttpUtil();
            _httpClient = _BuilderHttpUtil.BuildClient();
        }

        /// <summary>
        /// Realiza una consulta HTTP a la API Red utilizando la URL y cabeceras proporcionadas.
        /// </summary>
        /// <param name="url">URL completa del endpoint al que se enviará la petición.</param>
        /// <param name="headers">Objeto que contiene las cabeceras HTTP requeridas para la petición.</param>
        /// <returns>Objeto HttpResponseMessage que contiene la respuesta del servidor.</returns>
        /// <exception cref="HttpRequestException">
        /// Se lanza cuando ocurre un error en la comunicación HTTP con el servidor.
        /// </exception>
        /// <exception cref="JsonException">
        /// Se lanza cuando hay un error al procesar datos JSON recibidos o enviados.
        /// </exception>
        /// <exception cref="Exception">
        /// Se lanza para cualquier otro error inesperado durante el proceso de consulta.
        /// </exception>
        public async Task<HttpResponseMessage> Inquiry(string url, HeadersRq headers)
        {
            try
            {
                Console.WriteLine($"[INFO] Iniciando solicitud a: {url}");

                ClearHeaders();

                HeaderMapper.AddInquiryHeaders(_httpClient, headers);

                // Realizamos la solicitud HTTP
                Console.WriteLine("[INFO] Enviando solicitud GET...");
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                Console.WriteLine($"[INFO] Respuesta recibida con código: {response.StatusCode}");
                Console.WriteLine($"[INFO] Respuesta recibida con código: {response.IsSuccessStatusCode}");

                // Verificamos si la respuesta fue exitosa
                response.EnsureSuccessStatusCode();

                return response;

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