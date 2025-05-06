using SPI_Delete_Service.model.enrollment;
using SPI_Delete_Service.model;
using SPI_Delete_Service.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Logging;
//using SPBVI_BACK_csharp_aot_libs_commons_serfi;
//using SPBVI_BACK_csharp_aot_libs_redeban_connection_serfi.constants;
//using SPBVI_BACK_csharp_aot_libs_redeban_connection_serfi.model.delete;
//using SPBVI_BACK_csharp_aot_libs_redeban_connection_serfi.model;
//using SPBVI_BACK_csharp_aot_libs_redeban_connection_serfi.util;
using System.Text.Json;
using SPI_Delete_Service.model.delete;
using SPI_Delete_Serviceconstants;
using SPI_Delete_Service.service.service.delete;
using SPI_Delete_Service.model.model;
using SPI_directory_service.Util;

namespace SPI_Delete_Service.service.delete
{
    public class RedDeleteAccountServiceImpl : IRedDeleteAccountService
    {
        /// <summary>
        /// Cliente HTTP estático compartido para todas las instancias del servicio.
        /// </summary>
        private static readonly HttpClient _httpClient;

        /// <summary>
        /// Utilidad para construir y configurar instancias de HttpClient.
        /// </summary>
        private static readonly BuilderHttpUtil _BuilderHttpUtil;

        private static readonly JsonSerializerOptions _jsonOptions;

        /// <summary>
        /// Constructor estático que inicializa los recursos compartidos.
        /// Configura el cliente HTTP una sola vez para su reutilización en todas las solicitudes.
        /// </summary>
        static RedDeleteAccountServiceImpl()
        {
            _BuilderHttpUtil = new BuilderHttpUtil();
            _httpClient = _BuilderHttpUtil.BuildClient();

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<HttpResponseMessage> DeleteKeyAsync(string url, HeadersRq headers, DeleteRq requestBody)
        {
            try
            {
                Console.WriteLine($"[INFO] Iniciando solicitud PUT Cancelacion a: {url}");

                ClearHeaders();

                HeaderMapper.AddInquiryHeaders(_httpClient, headers);

                // Configurar cabeceras adicionales específicas para POST
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ConstantsEnum.APPLICATION_JSON);
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", ConstantsEnum.APPLICATION_JSON);

                string jsonContent = JsonSerializer.Serialize(requestBody,_jsonOptions);

                Console.WriteLine($"[DEBUG] JSON a enviar: {jsonContent}");

                var content = new StringContent(jsonContent, Encoding.UTF8, ConstantsEnum.APPLICATION_JSON);

                Console.WriteLine("[INFO] Enviando solicitud PUT...");
                HttpResponseMessage response = await _httpClient.PutAsync(url, content);

                Console.WriteLine($"[INFO] Respuesta recibida con código: {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("[INFO] Solicitud PUT exitosa");
                }
                else
                {
                    Console.WriteLine($"[WARN] Solicitud PUT fallida con código: {response.StatusCode}");
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"[WARN] Respuesta de error: {responseContent}");
                }

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
