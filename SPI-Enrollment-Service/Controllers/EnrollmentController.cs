using Microsoft.AspNetCore.Mvc;
using SPI_directory_service.Utils;
using SPI_Enrollment_Service.model;
using SPI_Enrollment_Service.service.create;
using SPI_Enrollment_Service.util;
using SPI_Enrollment_Serviceconstants;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Models;
using Services;
using Models.enrollment;
using Models.openSearchModel;
using SPI_Enrollment_Service.Models.redeban.response;
using SPI_Enrollment_Service.constants;
using SPI_Enrollment_Service.Models.enrollment;
using SPI_Enrollment_Service.Mapper;
using SPI_Enrollment_Service.Models.redeban;

namespace SPI_directory_service.Controllers
{
    [ApiController]
    [Route("Directory/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        
        private readonly IRedEnrollmentService _enrollmentService;
        private readonly ValidateService validateService = new ValidateService();
        private readonly ILogger<EnrollmentController> _logger;
        private readonly UriUtil _uriUtil;
        private readonly IOpenSearchService openSearchService = new OpenSearchService();
        private readonly RedRqMapper redRqMapper = new RedRqMapper();
        private readonly RqMapperOs rqMapperOs = new RqMapperOs();



        public EnrollmentController(            
            IRedEnrollmentService enrollmentService,
            ILogger<EnrollmentController> logger
            )
        {
            _enrollmentService = enrollmentService;
            _logger = logger;
            _uriUtil = new UriUtil();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromHeader] EnrollmentAccountHeaders header, [FromBody] ReqBPostAccountRelationship body)
        {

                EnrollmentRq request = new EnrollmentRq();

                request.enrollmenAccountHeaders = header;
                request.reqBPostAccountRelationship = body;
                
                try
                {
                    _logger.LogInformation("Iniciando proceso de inscripción");
                    MessageInformation responseRedeban;
                    validateService.ValidateServiceModel(request);
                    OSDefinitive opSearchEntity = await openSearchService.SearchKey(request.reqBPostAccountRelationship.key.keyType,request.reqBPostAccountRelationship.key.keyId);
                    _logger.LogInformation($"opSearchEntity: {opSearchEntity.ToString()}");

                   if(opSearchEntity == null){
                        _logger.LogInformation("Iniciando proceso de conexión a cámara");
                        //string apiUri = _uriUtil.BuildUri(ConstantsEnum.ENROLLMENT);
                        string apiUri = "https://b893c53b-3fb1-43b9-b7c2-4a85801e0e88.mock.pstmn.io/Enrrollment";
                        _logger.LogInformation($"URL completa: {apiUri}");
                        // Obtener headers de la solicitud

                        HeadersRq headers = redRqMapper.MapHeadersFromRequest(request.enrollmenAccountHeaders);
                        EnrollmentRqRed enrollmentBody = redRqMapper.MapBodyFromRequest(request.reqBPostAccountRelationship);

                        // Llamar al servicio
                         responseRedeban = await _enrollmentService.Create(apiUri, headers, enrollmentBody);

                        if(responseRedeban.msgCode == StatusCodeEnum.RED_PERSON_SUCCESS_STATUS_CODE || responseRedeban.msgCode == StatusCodeEnum.RED_PERSON_CREATED_STATUS_CODE){
                            _logger.LogInformation("Se creo la llave exitosamente: " + responseRedeban.ToString());
                        }else{
                            _logger.LogError($"No se pudo crear la llave: " + responseRedeban.ToString());
                            throw new Exception();
                        }
                    }else{
                        _logger.LogError($"Se encontró un registro con la llave: " + request.reqBPostAccountRelationship.key.keyId);
                    throw new SerfiException(ResponseServiceEnum.FOUND_KEY.getErrorCode(), ResponseServiceEnum.FOUND_KEY.getMessage(), ResponseServiceEnum.FOUND_KEY.getHttpCode());
                    }

                    _logger.LogInformation("Iniciando proceso de guardado en open search.");
                    OSDefinitive entityToSave = rqMapperOs.mapOSDefinitiveFromRequest(request);
                    await openSearchService.SaveKey(entityToSave);
                _logger.LogInformation("guardado en open search.");

                MsgInformationResponseSerfi responseService = rqMapperOs.responseSuccess(entityToSave, request, responseRedeban);

                    return responseService;
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