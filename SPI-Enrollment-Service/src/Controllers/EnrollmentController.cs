using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using domain.constants;
using application.Services;
using application.mapper;
using domain.models;
using domain.models.enrollment;
using domain.models.redeban;
using domain.models.redeban.response;
using application.Util;
using application.interfaces;
using application.util;
using System.ComponentModel.DataAnnotations;

namespace Controllers
{
    [ApiController]
    [Route("Directory/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        
        private readonly IRedEnrollmentService _enrollmentService;

        private readonly ValidateService validateService = new ValidateService();
        private readonly UriUtil _uriUtil;
        private readonly RedRqMapper _redRqMapper = new RedRqMapper();
        private readonly ResponseSerfiMapper _rsMapperSerfi = new ResponseSerfiMapper();
        private readonly HeaderSerfiMapper _headersMapper = new HeaderSerfiMapper();



        public EnrollmentController(            
            IRedEnrollmentService enrollmentService
            )
        {
            _enrollmentService = enrollmentService;
            _uriUtil = new UriUtil();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Required][FromHeader(Name = HeadersSerfiEnum.API_KEY)] string apiKeyHeader,
                                                [Required][FromHeader(Name = HeadersSerfiEnum.AUTHENTICATION)] string authHeader,
                                                [Required][FromHeader(Name = HeadersSerfiEnum.UUID)] string uuidHeader,
                                                [Required][FromHeader(Name = HeadersSerfiEnum.TIMESTAMPS)] string timestampsHeader,
                                                [Required][FromHeader(Name = HeadersSerfiEnum.SYSTEMID)] string systemIdHeader,
                                                [FromBody] ReqBPostAccountRelationship body)
        {

            EnrollmentRq request = new EnrollmentRq();

            request.enrollmenAccountHeaders = _headersMapper.mapHeaders(apiKeyHeader, authHeader, uuidHeader, timestampsHeader, systemIdHeader);
            string headers = await UtilCommons.Object2String(request.enrollmenAccountHeaders);
            Console.WriteLine("headers: " + headers);

            request.reqBPostAccountRelationship = body;
            string body1 = await UtilCommons.Object2String(request.reqBPostAccountRelationship);
            Console.WriteLine("body: " + body1);

            try
            {
                Console.WriteLine("Iniciando proceso de inscripción");
                MsgInformationResponse responseRedeban;
                validateService.ValidateServiceModel(request);
                Console.WriteLine("Termino el proceso de validacion");

                //OSDefinitive opSearchEntity = await _openSearchService.SearchKey(request.reqBPostAccountRelationship.key.keyType, request.reqBPostAccountRelationship.key.keyId);
                //_logger.LogInformation($"opSearchEntity: {opSearchEntity.ToString()}");

                //if (opSearchEntity == null)
                //{
                Console.WriteLine("Iniciando proceso de conexión a cámara");

                responseRedeban = await callRedebanAsync(request);
                //}
                //else
                //{
                    //_logger.LogError($"Se encontró un registro con la llave: " + request.reqBPostAccountRelationship.key.keyId);
                    //throw new SerfiException(ResponseServiceEnum.FOUND_KEY.getErrorCode(), ResponseServiceEnum.FOUND_KEY.getMessage(), ResponseServiceEnum.FOUND_KEY.getHttpCode());
                //}

                //Console.WriteLine("Iniciando proceso de guardado en open search.");
                //OSDefinitive entityToSave = _rqMapperOs.mapOSDefinitiveFromRequest(request);
                //await _openSearchService.SaveKey(entityToSave);
                //Console.WriteLine("guardado en open search.");

                MsgInformationResponseSerfi responseService = _rsMapperSerfi.responseSuccess(request, responseRedeban.messageInformation);

                //return responseService;
                return Ok(responseService);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error al procesar JSON: {ex.Message}");

                return BadRequest(new
                {
                    error = "Formato JSON inválido",
                    message = ex.Message
                });
            }
            catch (SerfiException ex)
            {
                Console.WriteLine($"Error de serfinanzas: {ex.Message}");

                return BadRequest(new
                {
                    code = ex.errorCode,
                    error = ex.message
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la inscripción: {ex.Message}");

                return StatusCode(500, new
                {
                    error = "Error interno del servidor",
                    message = ex.Message,
                    timestamp = DateTime.UtcNow.ToString()
                });
            }
        }

        private async Task<MsgInformationResponse> callRedebanAsync(EnrollmentRq request)
        {
        
            MsgInformationResponse responseRedeban;
            string apiUri = _uriUtil.BuildUri(ConstantsEnum.BASE_URI);

            Console.WriteLine($"URL completa: {apiUri}");

            // Obtener headers de la solicitud
            HeadersRq headersRq = _redRqMapper.MapHeadersFromRequest(request.enrollmenAccountHeaders);

            Console.WriteLine("headers: " + await UtilCommons.Object2String(headersRq));

            EnrollmentRqRed enrollmentBody = _redRqMapper.MapBodyFromRequest(request.reqBPostAccountRelationship);

            Console.WriteLine("Body: " + await UtilCommons.Object2String(enrollmentBody));

            // Llamar al servicio
            responseRedeban = await _enrollmentService.Create(apiUri, headersRq, enrollmentBody);

            Console.WriteLine("Respuesta de redeban: " + await UtilCommons.Object2String(responseRedeban));

            if (responseRedeban.messageInformation.msgCode == StatusCodeEnum.RED_PERSON_SUCCESS_STATUS_CODE || responseRedeban.messageInformation.msgCode == StatusCodeEnum.RED_PERSON_CREATED_STATUS_CODE)
            {
                Console.WriteLine("Se creo la llave exitosamente: " + await UtilCommons.Object2String(responseRedeban));
            }
            else
            {
                Console.WriteLine($"No se pudo crear la llave: " +await UtilCommons.Object2String(responseRedeban));
                throw new SerfiException(ResponseServiceEnum.ERROR_REDEBAN_CONNECTION.getErrorCode(), ResponseServiceEnum.ERROR_REDEBAN_CONNECTION.getMessage(), ResponseServiceEnum.ERROR_REDEBAN_CONNECTION.getHttpCode());
            }

            return responseRedeban;
        }
    }
}