using Microsoft.AspNetCore.Mvc;
using SPI_Update_Service.service.update;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using application.Util;
using domain.models;
using domain.constants;
using application.util;
using domain.models.enrollment;
using application.mapper;
using application.Services;
using domain.models.redeban;
using SPI_Update_Service.domain.models.redeban;
using domain.models.openSearchModel;
using application.interfaces;
using domain.models.redeban.response;

namespace SPI_directory_service.Controllers
{
    [ApiController]
    [Route("Directory/[controller]")]
    public class UpdateController : ControllerBase
    {
        private readonly IRedUpdateService _updateService;
        private readonly ILogger<UpdateController> _logger;
        private readonly UriUtil _uriUtil;
        private readonly ValidateService validateService = new ValidateService();
        private readonly HeaderSerfiMapper _headersMapper = new HeaderSerfiMapper();
        private readonly RedRqMapper _redRqMapper = new RedRqMapper();
        private readonly IOpenSearchService _openSearchService = new OpenSearchService();
        private readonly RqMapperOs _rqMapperOs = new RqMapperOs();

        public UpdateController(
            IRedUpdateService updateService,
            ILogger<UpdateController> logger)
        {
            _updateService = updateService;
            _logger = logger;
            _uriUtil = new UriUtil();
        }

        [HttpPatch("account")]
        public async Task<IActionResult> UpdateAccount([FromHeader(Name = HeadersSerfiEnum.API_KEY)] string apiKeyHeader,
                                                    [FromHeader(Name = HeadersSerfiEnum.AUTHENTICATION)] string authHeader,
                                                    [FromHeader(Name = HeadersSerfiEnum.UUID)] string uuidHeader,
                                                    [FromHeader(Name = HeadersSerfiEnum.TIMESTAMPS)] string timestampsHeader,
                                                    [FromHeader(Name = HeadersSerfiEnum.SYSTEMID)] string systemIdHeader
                                                    , [FromBody] ReqBPatchAccount body)
        {

            //validate request
            //Validar que la llave exista
            //El estado debe de la llave consultada debe estar activa
            //el num documento del request debe ser el mismo que el id de os
            // Setear campos que se quieran cambiar
            // Consumo redeban
            // Validar respuesta de redeban
            // Guarda nuevo resgistro en opSearch
            // elimina resgitro anterior en opSearch


            UpdateAccountRq request = new UpdateAccountRq();
            request.updateHeaders = _headersMapper.mapHeaders(apiKeyHeader, authHeader, uuidHeader, timestampsHeader, systemIdHeader);
            string headers = await UtilCommons.Object2String(request.updateHeaders);
            _logger.LogInformation("headers: " + headers);

            request.reqBPatchAccount = body;
            string body1 = await UtilCommons.Object2String(request.reqBPatchAccount);
            _logger.LogInformation("body: " + body1);

            try
            {
                _logger.LogInformation("Iniciando proceso de actualización de cuenta");

                MessageInformation responseRedeban;

                validateService.ValidateServiceUpdateKeyModel(request);

                _logger.LogInformation("Termino el proceso de validacion");

                //Buscamos llave
                OSDefinitive opSearchOldEntity = await _openSearchService.SearchKey(request.reqBPatchAccount.key.keyType, request.reqBPatchAccount.key.keyId);

                string opSearchOldEntityPrint = await UtilCommons.Object2String(opSearchOldEntity);
                _logger.LogInformation("OS entity: " + opSearchOldEntityPrint);

                validateService.validateOSEntityAccount(request, opSearchOldEntity);

                //string apiUri = _uriUtil.BuildUri(ConstantsEnum.ACCOUNT_UPDATE);
                string apiUri = "https://b893c53b-3fb1-43b9-b7c2-4a85801e0e88.mock.pstmn.io/AccountUpdate";

                _logger.LogInformation($"URL completa: {apiUri}");

                // Obtener headers de la solicitud
                HeadersRq headersRq = _redRqMapper.MapHeadersFromRequest(request.updateHeaders);

                UpdateAcctRq updateBody = _redRqMapper.MapBodyAccountFromRequest(request.reqBPatchAccount, opSearchOldEntity);

                // Llamar al servicio
                MessageInformation response = await _updateService.UpdateAccountAsync(apiUri, headersRq, updateBody);

                if (response.msgCode == StatusCodeEnum.RED_PERSON_SUCCESS_STATUS_CODE || response.msgCode == StatusCodeEnum.RED_PERSON_CREATED_STATUS_CODE)
                {
                    _logger.LogInformation("Se modificó el producto exitosamente: " + response.ToString());
                }
                else
                {
                    _logger.LogError($"No se pudo modificar el producto: " + response.ToString());
                    //Fata exception
                    throw new Exception();
                }

                _logger.LogInformation("Iniciando proceso de guardado en open search.");
                // Falta mapeo
                OSDefinitive entityToSave = _rqMapperOs.mapUpdateAccountOSDefinitiveFromRequest(request, opSearchOldEntity);

                await _openSearchService.SaveKey(entityToSave);

                await _openSearchService.DeleteKey(opSearchOldEntity.key.keyType, opSearchOldEntity.key.keyId);

                _logger.LogInformation("Se modificó en open search correctamente.");


                MsgInformationResponseSerfi responseService = _rqMapperOs.mapMessageResponseAccount(entityToSave, request, response);

                _logger.LogInformation("Finalizo el proceso");

                return Ok(responseService);
                //return null;
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
            public async Task<IActionResult> UpdateKey([FromHeader(Name = HeadersSerfiEnum.API_KEY)] string apiKeyHeader,
                                                    [FromHeader(Name = HeadersSerfiEnum.AUTHENTICATION)] string authHeader,
                                                    [FromHeader(Name = HeadersSerfiEnum.UUID)] string uuidHeader,
                                                    [FromHeader(Name = HeadersSerfiEnum.TIMESTAMPS)] string timestampsHeader,
                                                    [FromHeader(Name = HeadersSerfiEnum.SYSTEMID)] string systemIdHeader
                                                    , [FromBody] ReqBPatchKey body)
            {            

            UpdateKeyRq request = new UpdateKeyRq();
            request.updateHeaders = _headersMapper.mapHeaders(apiKeyHeader, authHeader, uuidHeader, timestampsHeader, systemIdHeader);
            string headers = await UtilCommons.Object2String(request.updateHeaders);
            _logger.LogInformation("headers: " + headers);

            request.reqBPatchKey = body;
            string body1 = await UtilCommons.Object2String(request.reqBPatchKey);
            _logger.LogInformation("body: " + body1);


            try
                {
                _logger.LogInformation("Iniciando proceso de actualización de llave");
                MessageInformation responseRedeban;
                validateService.ValidateServiceUpdateKeyModel(request);

                _logger.LogInformation("Termino el proceso de validacion");
                OSDefinitive opSearchOldEntity = await _openSearchService.SearchKey(request.reqBPatchKey.key.oldKeyType, request.reqBPatchKey.key.oldKeyId);
                string opSearchOldEntityPrint = await UtilCommons.Object2String(opSearchOldEntity);
                _logger.LogInformation("OS entity: " + opSearchOldEntityPrint);

                validateService.validateOSEntity(request, opSearchOldEntity);

                //string apiUri = _uriUtil.BuildUri(ConstantsEnum.KEY_UPDATE);
                string apiUri = "https://b893c53b-3fb1-43b9-b7c2-4a85801e0e88.mock.pstmn.io/KeyUpdate";

                _logger.LogInformation($"URL completa: {apiUri}");

                // Obtener headers de la solicitud
                HeadersRq headersRq = _redRqMapper.MapHeadersFromRequest(request.updateHeaders);
                UpdateKeyPersonRq updateBody = _redRqMapper.MapBodyKeyFromRequest(request);

                // Llamar al servicio
                MessageInformation response = await _updateService.UpdateKeyAsync(apiUri, headersRq, updateBody);

                if (response.msgCode == StatusCodeEnum.RED_PERSON_SUCCESS_STATUS_CODE || response.msgCode == StatusCodeEnum.RED_PERSON_CREATED_STATUS_CODE)
                {
                    _logger.LogInformation("Se modificó la llave exitosamente: " + response.ToString());
                }
                else
                {
                    _logger.LogError($"No se pudo modificar la llave: " + response.ToString());
                    throw new Exception();
                }

                _logger.LogInformation("Iniciando proceso de guardado en open search.");
                OSDefinitive entityToSave = _rqMapperOs.mapUpdateKeyOSDefinitiveFromRequest(request, opSearchOldEntity);

                await _openSearchService.SaveKey(entityToSave);

                await _openSearchService.DeleteKey(opSearchOldEntity.key.keyType, opSearchOldEntity.key.keyId);

                _logger.LogInformation("Se modificó en open search correctamente.");


                MsgInformationResponseSerfi responseService = _rqMapperOs.mapMessageResponse(entityToSave, request, response);

                _logger.LogInformation("Finalizo el proceso");

                return Ok(responseService);
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
