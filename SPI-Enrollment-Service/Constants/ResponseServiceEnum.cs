using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPI_Enrollment_Service.constants
{
    /// <summary>
    /// ResponseServiceEnum - Enum que contiene la información necesaria
    /// para las respuestas de la lambda.
    /// </summary>
    public enum ResponseServiceEnum
    {
        /// <summary>
        /// Constante de error en caso de que se presente un fallo al intentar operación sobre DynamoDB.
        /// </summary>
        ERROR_TEC_EXCEPTION_VAULT_CONN,
        SUCCESS_INQUIRY_KEY
    }

    /// <summary>
    /// Extensiones para ResponseServiceEnum
    /// </summary>
    public static class ResponseServiceEnumExtensions
    {
        /// <summary>
        /// Obtiene el código de estado HTTP
        /// </summary>
        public static int GetStatusCode(this ResponseServiceEnum responseService)
        {
            return responseService switch
            {
                ResponseServiceEnum.ERROR_TEC_EXCEPTION_VAULT_CONN => 500,
                ResponseServiceEnum.SUCCESS_INQUIRY_KEY => 200,
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }

        /// <summary>
        /// Obtiene el código de estado del servidor
        /// </summary>
        public static string GetServerStatusCode(this ResponseServiceEnum responseService)
        {
            return responseService switch
            {
                ResponseServiceEnum.ERROR_TEC_EXCEPTION_VAULT_CONN => "500",
                ResponseServiceEnum.SUCCESS_INQUIRY_KEY => "200",
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }

        /// <summary>
        /// Obtiene la severidad del error
        /// </summary>
        public static string GetSeverity(this ResponseServiceEnum responseService)
        {
            return responseService switch
            {
                ResponseServiceEnum.ERROR_TEC_EXCEPTION_VAULT_CONN => "Error",
                ResponseServiceEnum.SUCCESS_INQUIRY_KEY => "Success",
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }

        /// <summary>
        /// Obtiene la descripción del estado
        /// </summary>
        public static string GetStatusDesc(this ResponseServiceEnum responseService)
        {
            return responseService switch
            {
                ResponseServiceEnum.ERROR_TEC_EXCEPTION_VAULT_CONN => "Error al intentar operación sobre directorio federado",
                ResponseServiceEnum.SUCCESS_INQUIRY_KEY => "Consulta exitosa",
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }

        /// <summary>
        /// Obtiene el código de estado adicional
        /// </summary>
        public static int GetAdditionalStatusCode(this ResponseServiceEnum responseService)
        {
            return responseService switch
            {
                ResponseServiceEnum.ERROR_TEC_EXCEPTION_VAULT_CONN => 500,
                ResponseServiceEnum.SUCCESS_INQUIRY_KEY => 200,
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }

        /// <summary>
        /// Obtiene la descripción adicional del estado
        /// </summary>
        public static string GetAdditionalStatusDesc(this ResponseServiceEnum responseService)
        {
            return responseService switch
            {
                ResponseServiceEnum.ERROR_TEC_EXCEPTION_VAULT_CONN => "VaultSync",
                ResponseServiceEnum.SUCCESS_INQUIRY_KEY => "InquirySucces",
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }
    }
}