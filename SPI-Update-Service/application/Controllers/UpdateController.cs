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
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OpenSearch.Client;

namespace application.controllers
{
    [ApiController]
    [Route("Directory/[controller]")]
    public class UpdateController : ControllerBase
    {
        private readonly IRedUpdateService _updateService;
        private readonly UriUtil _uriUtil;
        private readonly ValidateService validateService = new ValidateService();
        private readonly HeaderSerfiMapper _headersMapper = new HeaderSerfiMapper();
        private readonly RedRqMapper _redRqMapper = new RedRqMapper();
        private readonly IOpenSearchService _openSearchService = new OpenSearchService();
        private readonly RqMapperOs _rqMapperOs = new RqMapperOs();
        private readonly ResponseSerfiMapper _rsSerfiMapper = new ResponseSerfiMapper();

        public UpdateController(
            IRedUpdateService updateService)
        {
            _updateService = updateService;
            _uriUtil = new UriUtil();
        }

        [HttpPatch("account")]
        public async Task<IActionResult> UpdateAccount([Required][FromHeader(Name = HeadersSerfiEnum.API_KEY)] string apiKeyHeader,
                                                       [Required][FromHeader(Name = HeadersSerfiEnum.AUTHENTICATION)] string authHeader,
                                                       [Required][FromHeader(Name = HeadersSerfiEnum.UUID)] string uuidHeader,
                                                       [Required][FromHeader(Name = HeadersSerfiEnum.TIMESTAMPS)] string timestampsHeader,
                                                       [Required][FromHeader(Name = HeadersSerfiEnum.SYSTEMID)] string systemIdHeader,
                                                       [FromBody] ReqBPatchAccount body)
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
            Console.WriteLine("headers: " + headers);

            request.reqBPatchAccount = body;
            string body1 = await UtilCommons.Object2String(request.reqBPatchAccount);
            Console.WriteLine("body: " + body1);

            try
            {
                Console.WriteLine("Iniciando proceso de actualización de cuenta");

                MsgInformationResponse responseRedeban;

                validateService.ValidateServiceUpdateAccountModel(request);

                Console.WriteLine("Termino el proceso de validacion");

                //Buscamos llave
                //OSDefinitive opSearchOldEntity = await _openSearchService.SearchKey(request.reqBPatchAccount.key.keyType, request.reqBPatchAccount.key.keyId);

                //string opSearchOldEntityPrint = await UtilCommons.Object2String(opSearchOldEntity);
                //Console.WriteLine("OS entity: " + opSearchOldEntityPrint);

                //validateService.validateOSEntityAccount(request, opSearchOldEntity);

                string apiUri = _uriUtil.BuildUriAccount(request.reqBPatchAccount.key.keyId, request.reqBPatchAccount.key.keyType);

                //string apiUri = "https://b893c53b-3fb1-43b9-b7c2-4a85801e0e88.mock.pstmn.io/AccountUpdate";

                Console.WriteLine($"URL completa: {apiUri}");

                // Obtener headers de la solicitud
                HeadersRq headersRq = _redRqMapper.MapHeadersFromRequest(request.updateHeaders);

                UpdateAcctRq updateBody = _redRqMapper.MapBodyAccountFromRequest(request.reqBPatchAccount);

                // Llamar al servicio
                responseRedeban = await _updateService.UpdateAccountAsync(apiUri, headersRq, updateBody);

                Console.WriteLine("Respuesta de redeban: " + await UtilCommons.Object2String(responseRedeban));
                if (responseRedeban.messageInformation.msgCode == StatusCodeEnum.RED_PERSON_SUCCESS_STATUS_CODE || responseRedeban.messageInformation.msgCode == StatusCodeEnum.RED_PERSON_CREATED_STATUS_CODE)
                {
                    Console.WriteLine("Se modificó el producto exitosamente. ");
                }
                else
                {
                    Console.WriteLine($"No se pudo modificar el producto. ");
                    throw new SerfiException(ResponseServiceEnum.SERVICE_ACCOUNT_ERROR.getErrorCode(), ResponseServiceEnum.SERVICE_ACCOUNT_ERROR.getMessage(), ResponseServiceEnum.SERVICE_ACCOUNT_ERROR.getHttpCode());
                }

                //Console.WriteLine("Iniciando proceso de guardado en open search.");
                // Falta mapeo
                //OSDefinitive entityToSave = _rqMapperOs.mapUpdateAccountOSDefinitiveFromRequest(request, opSearchOldEntity);

                //await _openSearchService.SaveKey(entityToSave);

                //await _openSearchService.DeleteKey(opSearchOldEntity.key.keyType, opSearchOldEntity.key.keyId);

                //Console.WriteLine("Se modificó en open search correctamente.");


                //MsgInformationResponseSerfi responseService = _rsSerfiMapper.mapMessageResponseAccount(entityToSave, request, response);
                MsgInformationResponseSerfi responseService = _rsSerfiMapper.mapMessageResponseAccount(request, responseRedeban);


                Console.WriteLine("Finalizo el proceso");

                return Ok(responseService);
                //return null;
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

        [HttpPatch("key")]
        public async Task<IActionResult> UpdateKey([FromHeader(Name = HeadersSerfiEnum.API_KEY)] string apiKeyHeader,
                                                   [FromHeader(Name = HeadersSerfiEnum.AUTHENTICATION)] string authHeader,
                                                   [FromHeader(Name = HeadersSerfiEnum.UUID)] string uuidHeader,
                                                   [FromHeader(Name = HeadersSerfiEnum.TIMESTAMPS)] string timestampsHeader,
                                                   [FromHeader(Name = HeadersSerfiEnum.SYSTEMID)] string systemIdHeader,
                                                   [FromBody] ReqBPatchKey body)
        {

            UpdateKeyRq request = new UpdateKeyRq();
            request.updateHeaders = _headersMapper.mapHeaders(apiKeyHeader, authHeader, uuidHeader, timestampsHeader, systemIdHeader);
            string headers = await UtilCommons.Object2String(request.updateHeaders);
            Console.WriteLine("headers: " + headers);

            request.reqBPatchKey = body;
            string body1 = await UtilCommons.Object2String(request.reqBPatchKey);
            Console.WriteLine("body: " + body1);


            try
            {
                Console.WriteLine("Iniciando proceso de actualización de llave");
                MsgInformationResponse responseRedeban;
                validateService.ValidateServiceUpdateKeyModel(request);

                Console.WriteLine("Termino el proceso de validacion");
                //OSDefinitive opSearchOldEntity = await _openSearchService.SearchKey(request.reqBPatchKey.key.oldKeyType, request.reqBPatchKey.key.oldKeyId);
                //string opSearchOldEntityPrint = await UtilCommons.Object2String(opSearchOldEntity);
                //Console.WriteLine("OS entity: " + opSearchOldEntityPrint);

                //validateService.validateOSEntity(request, opSearchOldEntity);

                //string apiUri = _uriUtil.BuildUri(ConstantsEnum.KEY_UPDATE);
                string apiUri = _uriUtil.BuildUriKey(request.reqBPatchKey.custInfo.custIdent.custIdentId);
                //string apiUri = "https://b893c53b-3fb1-43b9-b7c2-4a85801e0e88.mock.pstmn.io/KeyUpdate";

                Console.WriteLine($"URL completa: {apiUri}");

                // Obtener headers de la solicitud
                HeadersRq headersRq = _redRqMapper.MapHeadersFromRequest(request.updateHeaders);
                UpdateKeyPersonRq updateBody = _redRqMapper.MapBodyKeyFromRequest(request);

                // Llamar al servicio
                MsgInformationResponse response = await _updateService.UpdateKeyAsync(apiUri, headersRq, updateBody);

                if (response.messageInformation.msgCode == StatusCodeEnum.RED_PERSON_SUCCESS_STATUS_CODE || response.messageInformation.msgCode == StatusCodeEnum.RED_PERSON_CREATED_STATUS_CODE)
                {
                    Console.WriteLine("Se modificó la llave exitosamente: " + response.ToString());
                }
                else
                {
                    Console.WriteLine($"No se pudo modificar la llave: " + response.ToString());
                    throw new SerfiException(ResponseServiceEnum.SERVICE_ACCOUNT_ERROR.getErrorCode(), ResponseServiceEnum.SERVICE_ACCOUNT_ERROR.getMessage(), ResponseServiceEnum.SERVICE_ACCOUNT_ERROR.getHttpCode());
                }

                //Console.WriteLine("Iniciando proceso de guardado en open search.");
                //OSDefinitive entityToSave = _rqMapperOs.mapUpdateKeyOSDefinitiveFromRequest(request, opSearchOldEntity);

                //await _openSearchService.SaveKey(entityToSave);

                //await _openSearchService.DeleteKey(opSearchOldEntity.key.keyType, opSearchOldEntity.key.keyId);

                //Console.WriteLine("Se modificó en open search correctamente.");


                MsgInformationResponseSerfi responseService = _rsSerfiMapper.mapMessageResponseKey( request, response);

                Console.WriteLine("Finalizo el proceso");

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
    }
}
