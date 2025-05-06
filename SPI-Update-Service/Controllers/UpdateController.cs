using Microsoft.AspNetCore.Mvc;
using SPI_directory_service.Utils;
using SPI_Update_Service.model.update;
using SPI_Update_Service.model;
using SPI_Update_Service.service.update;
using SPI_Update_Service.util;
using SPI_lambda_consultaconstants;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SPI_directory_service.Controllers
{
    [ApiController]
    [Route("Directory/[controller]")]
    public class UpdateController : ControllerBase
    {
        private readonly IRedUpdateService _updateService;
        private readonly ILogger<UpdateController> _logger;
        private readonly UriUtil _uriUtil;

        public UpdateController(
            IRedUpdateService updateService,
            ILogger<UpdateController> logger)
        {
            _updateService = updateService;
            _logger = logger;
            _uriUtil = new UriUtil();
        }

        [HttpPatch("account")]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAcctRq request)
        {
            try
            {
                _logger.LogInformation("Iniciando proceso de actualización de cuenta");

                // Validación del modelo
                if (request == null)
                {
                    _logger.LogWarning("Solicitud de actualización inválida: Cuerpo vacío");
                    return BadRequest(new { error = "Solicitud inválida", message = "El cuerpo de la solicitud no puede estar vacío" });
                }

                //string apiUri = _uriUtil.BuildUri(ConstantsEnum.ACCOUNT_UPDATE);
                string apiUri = "https://b893c53b-3fb1-43b9-b7c2-4a85801e0e88.mock.pstmn.io/AccountUpdate";

                _logger.LogInformation($"URL completa: {apiUri}");

                // Obtener headers de la solicitud
                HeadersRq headers = HeaderMapper.MapHeadersFromRequest(Request);

                // Llamar al servicio
                HttpResponseMessage response = await _updateService.UpdateAccountAsync(apiUri, headers, request);

                // Procesar respuesta
                string responseBody = await response.Content.ReadAsStringAsync();

                return StatusCode((int)response.StatusCode, responseBody);
            }
            catch (JsonException ex)
            {
                _logger.LogError($"Error al procesar JSON: {ex.Message}");

                return BadRequest(new
                {
                    error = "Formato JSON inválido",
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en la actualización de cuenta: {ex.Message}");

                return StatusCode(500, new
                {
                    error = "Error interno del servidor",
                    message = ex.Message,
                    timestamp = DateTime.UtcNow.ToString()
                });
            }
        }

        [HttpPatch("key")]
        public async Task<IActionResult> UpdateKey([FromBody] UpdateKeyPersonRq request)
        {
            try
            {
                _logger.LogInformation("Iniciando proceso de actualización de llave");

                // Validación del modelo
                if (request == null)
                {
                    _logger.LogWarning("Solicitud de actualización inválida: Cuerpo vacío");
                    return BadRequest(new { error = "Solicitud inválida", message = "El cuerpo de la solicitud no puede estar vacío" });
                }

                //string apiUri = _uriUtil.BuildUri(ConstantsEnum.KEY_UPDATE);
                string apiUri = "https://b893c53b-3fb1-43b9-b7c2-4a85801e0e88.mock.pstmn.io/KeyUpdate";

                _logger.LogInformation($"URL completa: {apiUri}");

                // Obtener headers de la solicitud
                HeadersRq headers = HeaderMapper.MapHeadersFromRequest(Request);

                // Llamar al servicio
                HttpResponseMessage response = await _updateService.UpdateKeyAsync(apiUri, headers, request);

                // Procesar respuesta
                string responseBody = await response.Content.ReadAsStringAsync();

                return StatusCode((int)response.StatusCode, responseBody);
            }
            catch (JsonException ex)
            {
                _logger.LogError($"Error al procesar JSON: {ex.Message}");

                return BadRequest(new
                {
                    error = "Formato JSON inválido",
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en la actualización de llave: {ex.Message}");

                return StatusCode(500, new
                {
                    error = "Error interno del servidor",
                    message = ex.Message,
                    timestamp = DateTime.UtcNow.ToString()
                });
            }
        }
    }
}
