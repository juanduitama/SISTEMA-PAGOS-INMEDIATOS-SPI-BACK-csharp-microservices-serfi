using Microsoft.AspNetCore.Mvc;
using SPI_directory_service.Utils;
using SPI_Delete_Service.model.delete;
using SPI_Delete_Service.model;
using SPI_Delete_Service.service.service.delete;
using SPI_Delete_Service.util;
using SPI_Delete_Serviceconstants;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace SPI_directory_service.Controllers
{
    [ApiController]
    [Route("Directory/[controller]")]
    public class DeleteController : ControllerBase
    {
        private readonly IRedDeleteAccountService _deleteService;
        private readonly ILogger<DeleteController> _logger;
        private readonly UriUtil _uriUtil;

        public DeleteController(
            IRedDeleteAccountService deleteService,
            ILogger<DeleteController> logger)
        {
            _deleteService = deleteService;
            _logger = logger;
            _uriUtil = new UriUtil();
        }

        [HttpPut("cancellation")]
        public async Task<IActionResult> DeleteKey([FromBody] DeleteRq request)
        {
            try
            {
                _logger.LogInformation("Iniciando proceso de eliminación de llave");

                // Validación del modelo
                if (request == null)
                {
                    _logger.LogWarning("Solicitud de eliminación inválida: Cuerpo vacío");
                    return BadRequest(new { error = "Solicitud inválida", message = "El cuerpo de la solicitud no puede estar vacío" });
                }

                //string apiUri = _uriUtil.BuildUri(ConstantsEnum.DELETE);
                string apiUri = "https://b893c53b-3fb1-43b9-b7c2-4a85801e0e88.mock.pstmn.io/Cancellation";
                _logger.LogInformation($"URL completa: {apiUri}");

                // Obtener headers de la solicitud
                HeadersRq headers = HeaderMapper.MapHeadersFromRequest(Request);

                // Llamar al servicio
                HttpResponseMessage response = await _deleteService.DeleteKeyAsync(apiUri, headers, request);

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
                _logger.LogError($"Error en la eliminación: {ex.Message}");

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