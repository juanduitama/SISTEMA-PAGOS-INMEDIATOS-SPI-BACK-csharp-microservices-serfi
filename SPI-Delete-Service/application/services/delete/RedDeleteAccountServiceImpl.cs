using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

using SPI_Delete_Service.application.interfaces;
using SPI_Delete_Service.domain.models.redeban;
using domain.models.redeban.response;
using domain.models.redeban;
using application.Util;
using application.mapper;
using application.util;
using domain.constants;

namespace SPI_Delete_Service.application.services.delete
{
    public class RedDeleteAccountServiceImpl : IRedDeleteAccountService
    {
        /// <summary>
        /// Cliente HTTP estático compartido para todas las instancias del servicio.
        /// </summary>
        private  readonly HttpClient _httpClient;

        /// <summary>
        /// Utilidad para construir y configurar instancias de HttpClient.
        /// </summary>
        private  readonly BuilderHttpUtil _BuilderHttpUtil;

        private  readonly JsonSerializerOptions _jsonOptions;
        private  readonly RedRqMapper _redRqMapper = new RedRqMapper();



        /// <summary>
        /// Constructor estático que inicializa los recursos compartidos.
        /// Configura el cliente HTTP una sola vez para su reutilización en todas las solicitudes.
        /// </summary>
        public RedDeleteAccountServiceImpl()
        {
            _BuilderHttpUtil = new BuilderHttpUtil();
            _httpClient = _BuilderHttpUtil.BuildClient();

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<MessageInformation> DeleteKeyAsync(string url, HeadersRq headers, DeleteRq requestBody)
        {
            try
            {
                MessageInformation responseRedeban = new MessageInformation();

                Console.WriteLine($"[INFO] Iniciando solicitud PUT Cancelacion a: {url}");

                ClearHeaders();

                _redRqMapper.AddDeleteHeaders(_httpClient, headers);

                string jsonContent = await UtilCommons.Object2String(requestBody);

                Console.WriteLine($"[DEBUG] JSON a enviar: {jsonContent}");

                var content = new StringContent(jsonContent, Encoding.UTF8, ConstantsEnum.APPLICATION_JSON);

                string contentBody = await content.ReadAsStringAsync();

                Console.WriteLine("[INFO] Enviando solicitud PUT...");
                HttpResponseMessage response = await _httpClient.PutAsync(url, content);

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
