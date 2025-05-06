using Microsoft.AspNetCore.Mvc;
using Services.inquiry;
using SPI_Inquiry_Service.Utils;
using SPI_lambda_consulta.model;
using SPI_lambda_consulta.util;
using SPI_lambda_consultaconstants;
using static System.Net.WebRequestMethods;

namespace SPI_Inquiry_Service.Controllers
{
    [ApiController]
    [Route("Directory/[controller]")]
    public class InquiryController : ControllerBase
    {
        private readonly IRedInquiryService _inquiryService;
        private readonly ILogger<InquiryController> _logger;
        private readonly UriUtil _uriUtil;

        public InquiryController(
            IRedInquiryService inquiryService,
            ILogger<InquiryController> logger)
        {
            _inquiryService = inquiryService;
            _logger = logger;
            _uriUtil = new UriUtil();
        }

        [HttpGet("key/{RefId}")]
        public async Task<IActionResult> GetKeyByValue(string keyValue)
        {
            try
            {
                _logger.LogInformation($"Consultando llave por valor: {keyValue}");

                // Utilizando RouteValues
                //string apiUri = _uriUtil.BuildUri(ConstantsEnum.KEY_INQUIRY, HttpContext.Request.RouteValues);
                string apiUri = "https://b893c53b-3fb1-43b9-b7c2-4a85801e0e88.mock.pstmn.io/keyInquiry";


                // O utilizando el parámetro directamente
                // string apiUri = _uriUtil.BuildUri(ConstantsEnum.KEY_INQUIRY, keyValue);

                _logger.LogInformation($"URL completa: {apiUri}");

                HeadersRq headers = HeaderMapper.MapHeadersFromRequest(Request);
                HttpResponseMessage response = await _inquiryService.Inquiry(apiUri, headers);

                string responseBody = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, responseBody);
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
    }
}
