using application.interfaces;
using application.mapper;
using application.Services;
using application.util;
using application.Util;
using domain.constants;
using domain.models;
using domain.models.enrollment;
using domain.models.openSearchModel;
using domain.models.redeban;
using domain.models.redeban.response;
using Microsoft.AspNetCore.Mvc;
using OpenSearch.Client;
using SPI_Inquiry_Service.application.interfaces;
using System.ComponentModel.DataAnnotations;
using static System.Net.WebRequestMethods;

namespace SPI_Inquiry_Service.application.Controllers
{
    [ApiController]
    [Route("Directory/[controller]")]
    public class InquiryController : ControllerBase
    {
        private readonly IRedInquiryService _inquiryService;
        private readonly ILogger<InquiryController> _logger;
        private readonly UriUtil _uriUtil;
        private readonly ValidateService validateService = new ValidateService();
        private readonly IOpenSearchService _openSearchService = new OpenSearchService();
        private readonly RedRqMapper _redRqMapper = new RedRqMapper();
        private readonly RqMapperOs _rqMapperOs = new RqMapperOs();
        private readonly HeaderSerfiMapper _headersMapper = new HeaderSerfiMapper();

        public InquiryController(
            IRedInquiryService inquiryService,
            ILogger<InquiryController> logger)
        {
            _inquiryService = inquiryService;
            _logger = logger;
            _uriUtil = new UriUtil();
        }

        [HttpGet("inquiey/KeyInquiry")]
        public async Task<IActionResult> GetKeyByValue([Required][FromHeader(Name = HeadersSerfiEnum.API_KEY)] string apiKeyHeader,
                                                [Required][FromHeader(Name = HeadersSerfiEnum.AUTHENTICATION)] string authHeader,
                                                [Required][FromHeader(Name = HeadersSerfiEnum.UUID)] string uuidHeader,
                                                [Required][FromHeader(Name = HeadersSerfiEnum.TIMESTAMPS)] string timestampsHeader,
                                                [Required][FromHeader(Name = HeadersSerfiEnum.SYSTEMID)] string systemIdHeader,
                                                [Required][FromHeader(Name = HeadersSerfiEnum.KEYID)] string keyId)
        {

            InquiryHeaders request = new InquiryHeaders();
            request = _headersMapper.mapInquiryKeyHeaders(apiKeyHeader, authHeader, uuidHeader, timestampsHeader, systemIdHeader, keyId);
            string headers = await UtilCommons.Object2String(request);
            _logger.LogInformation("headers: " + headers);

            try
            {
                _logger.LogInformation("Iniciando proceso de busqueda de llave");
                MessageInformation responseRedeban;
                OSDefinitive opSearchEntity = await _openSearchService.SearchKey(request.keyId);
                MsgInformationResponseSerfi repsonse;

                if(opSearchEntity == null){
                    // Utilizando RouteValues
                    //string apiUri = _uriUtil.BuildUri(ConstantsEnum.KEY_INQUIRY, HttpContext.Request.RouteValues);
                    string apiUri = "https://b893c53b-3fb1-43b9-b7c2-4a85801e0e88.mock.pstmn.io/keyInquiry";


                    // O utilizando el parámetro directamente
                    // string apiUri = _uriUtil.BuildUri(ConstantsEnum.KEY_INQUIRY, keyValue);

                    _logger.LogInformation($"URL completa: {apiUri}");

                    HeadersRq headersRq = _redRqMapper.MapHeadersFromRequest(request);

                    MsgInformationResponse response = await _inquiryService.Inquiry(apiUri, headersRq);

                    if(response.key == null){
                        _logger.LogInformation("No hay información para la llave: " + request.keyId);
                        throw new SerfiException(ResponseServiceEnum.SERVICE_ACCOUNT_ERROR.getErrorCode(), ResponseServiceEnum.SERVICE_ACCOUNT_ERROR.getMessage(), ResponseServiceEnum.SERVICE_ACCOUNT_ERROR.getHttpCode());
                    }else{
                        response = mapinquiryKeyToRed(response, request);
                    }
                    
                    string responseBody = await response.Content.ReadAsStringAsync();
                }else{
                    return
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en la consulta por valor de llave: {ex.Message}");
                return StatusCode(500, new
                {
                    error = "Error interno del servidor",
                    message = ex.Message,
                    timestamp = DateTime.UtcNow.ToString()
                });
            }
        }

        [HttpGet("DocumentType/{DocumentType}/identification/{ID}")]
        public async Task<IActionResult> GetById()
        {
            try
            {
                //string apiUri = _uriUtil.BuildUri(ConstantsEnum.ID_INQUIRY, HttpContext.Request.RouteValues);
                string apiUri = "https://b893c53b-3fb1-43b9-b7c2-4a85801e0e88.mock.pstmn.io/DocInquiry";


                _logger.LogInformation($"URL completa: {apiUri}");

                HeadersRq headers = HeaderMapper.MapHeadersFromRequest(Request);
                HttpResponseMessage resHttp = await _inquiryService.Inquiry(apiUri, headers);

                string responseBody = await resHttp.Content.ReadAsStringAsync();

                return StatusCode((int)resHttp.StatusCode, responseBody);   

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en la consulta por clave: {ex.Message}");

                var errorObj = new
                {
                    error = "Error interno del servidor",
                    message = ex.Message,
                    timestamp = DateTime.UtcNow.ToString()
                };

                return StatusCode(500, errorObj);
            }
        }

        [HttpGet("MerchantInquiries/{MerchantId}")]
        public async Task<IActionResult> GetByMerchantId()
        {
            try
            {
                //string apiUri = _uriUtil.BuildUri(ConstantsEnum.MERCHANT_INQUIRY);
                string apiUri = "https://b893c53b-3fb1-43b9-b7c2-4a85801e0e88.mock.pstmn.io/MerchantInquiry";


                _logger.LogInformation($"URL completa: {apiUri}");

                //HeadersRq headers = HeaderMapper.MapHeadersFromRequest(Request);
                HttpResponseMessage resHttp = await _inquiryService.Inquiry(apiUri, headers);

                string responseBody = await resHttp.Content.ReadAsStringAsync();

                return StatusCode((int)resHttp.StatusCode, responseBody);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en la consulta por clave: {ex.Message}");

                var errorObj = new
                {
                    error = "Error interno del servidor",
                    message = ex.Message,
                    timestamp = DateTime.UtcNow.ToString()
                };

                return StatusCode(500, errorObj);
            }
        }
    }
}
