using Microsoft.AspNetCore.Mvc;
using SPI_directory_service.Utils;
using SPI_Enrollment_Service.model.enrollment;
using SPI_Enrollment_Service.model;
using SPI_Enrollment_Service.service.create;
using SPI_Enrollment_Service.util;
using SPI_Enrollment_Serviceconstants;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace SPI_directory_service.Controllers
{
    [ApiController]
    [Route("Directory/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IRedEnrollmentService _enrollmentService;
        private readonly ILogger<EnrollmentController> _logger;
        private readonly UriUtil _uriUtil;

        public EnrollmentController(
            IRedEnrollmentService enrollmentService,
            ILogger<EnrollmentController> logger)
        {
            _enrollmentService = enrollmentService;
            _logger = logger;
            _uriUtil = new UriUtil();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EnrollmentRq request)
        {
            try
            {
                _logger.LogInformation("Iniciando proceso de inscripción");

                // Validación básica del modelo
                if (request == null)
                {
                    _logger.LogWarning("Solicitud de inscripción inválida: Cuerpo vacío");
                    return BadRequest(new { error = "Solicitud inválida", message = "El cuerpo de la solicitud no puede estar vacío" });
                }

                // Validación de datos del cliente
                if (request.customer == null ||
                    (request.customer.type == ConstantsEnum.TYPE_PERSON && request.customer.person == null))
                {
                    _logger.LogWarning("Solicitud de inscripción inválida: Datos del cliente incompletos");
                    return BadRequest(new { error = "Datos de cliente incompletos o inválidos" });
                }

                //string apiUri = _uriUtil.BuildUri(ConstantsEnum.ENROLLMENT);
                string apiUri = "https://b893c53b-3fb1-43b9-b7c2-4a85801e0e88.mock.pstmn.io/Enrrollment";
                _logger.LogInformation($"URL completa: {apiUri}");

                // Obtener headers de la solicitud
                HeadersRq headers = HeaderMapper.MapHeadersFromRequest(Request);

                // Llamar al servicio
                HttpResponseMessage response = await _enrollmentService.Create(apiUri, headers, request);

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
                _logger.LogError($"Error en la inscripción: {ex.Message}");

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