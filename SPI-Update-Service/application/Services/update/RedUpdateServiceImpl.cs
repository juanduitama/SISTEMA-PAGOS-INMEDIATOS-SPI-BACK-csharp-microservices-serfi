using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using domain.models.redeban;
using application.Util;
using SPI_Update_Service.domain.models.redeban;
using domain.constants;
using application.mapper;
using domain.models.redeban.response;
using application.util;

namespace SPI_Update_Service.service.update
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

        /// <summary>
        /// Constructor estático que inicializa los recursos compartidos.
        /// Configura el cliente HTTP una sola vez para su reutilización en todas las solicitudes.
        /// </summary>
        public RedUpdateServiceImpl()
        {
            _BuilderHttpUtil = new BuilderHttpUtil();
            _httpClient = _BuilderHttpUtil.BuildClient();
            
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            redMapper = new RedRqMapper();

        }
        

        public async Task<MessageInformation> UpdateKeyAsync(string url, HeadersRq headers, UpdateKeyPersonRq requestBody)
        {
            try
            {
                MessageInformation responseRedeban = new MessageInformation();

                Console.WriteLine($"[INFO] Iniciando solicitud PATCH Update accouint a: {url}");

                ClearHeaders();

                redMapper.AddUpdateHeaders(_httpClient, headers);

                // Configurar cabeceras adicionales específicas para POST
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ConstantsEnum.APPLICATION_JSON);
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", ConstantsEnum.APPLICATION_JSON);
                
                string jsonContent = await UtilCommons.Object2String(requestBody);

                Console.WriteLine($"[DEBUG] JSON a enviar: {jsonContent}");

                var content = new StringContent(jsonContent, Encoding.UTF8, ConstantsEnum.APPLICATION_JSON);

                string contentBody = await content.ReadAsStringAsync();

                Console.WriteLine("[INFO] Enviando solicitud PATCH...");
                HttpResponseMessage response = await _httpClient.PatchAsync(url, content);

                Console.WriteLine($"[INFO] Respuesta recibida con código: {response.StatusCode}");

                string responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"[WARN] Respuesta de error: {responseContent}");
                
                responseRedeban = await UtilCommons.String2Object<MessageInformation>(responseContent);

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

            throw new NotImplementedException();
        }
        public async Task<MessageInformation> UpdateAccountAsync(string url, HeadersRq headers, UpdateAcctRq requestBody)
        {
            try
            {
                MessageInformation responseRedeban = new MessageInformation();
                Console.WriteLine($"[INFO] Iniciando solicitud PATCH Update account a: {url}");

                ClearHeaders();

                redMapper.AddUpdateHeaders(_httpClient, headers);

                // Configurar cabeceras adicionales específicas para POST
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", ConstantsEnum.APPLICATION_JSON);
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", ConstantsEnum.APPLICATION_JSON);

                string jsonContent = await UtilCommons.Object2String(requestBody);

                Console.WriteLine($"[DEBUG] JSON a enviar: {jsonContent}");

                var content = new StringContent(jsonContent, Encoding.UTF8, ConstantsEnum.APPLICATION_JSON);

                Console.WriteLine("[INFO] Enviando solicitud PATCH...");
                HttpResponseMessage response = await _httpClient.PatchAsync(url, content);

                Console.WriteLine($"[INFO] Respuesta recibida con código: {response.StatusCode}");

                string responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"[WARN] Respuesta de error: {responseContent}");

                responseRedeban = await UtilCommons.String2Object<MessageInformation>(responseContent);

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
