using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.constants
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
        NOT_FOUND_KEY,
        CONNECTION_OS,
        INVALID_KEY_TYPE,
        INVALID_KEY_ID,
        INVALID_KEY_STATUS,
        INVALID_DT_MODIFY,
        INVALID_VAULT_NAME,
        DIFFERENT_ID,
        DIFFERENT_TYPE,
        SERVICE_KEY_ERROR,
        SERVICE_ACCOUNT_ERROR,
        BAD_REQUEST_JSON,
        SERVICE_INTERNAL_ERROR
        

    }

    /// <summary>
    /// Extensiones para ResponseServiceEnum
    /// </summary>
    public static class ResponseServiceEnumExtensions
    {
        /// <summary>
        /// Obtiene el código de estado HTTP
        /// </summary>
        public static string getErrorCode(this ResponseServiceEnum responseService)
        {
            return responseService switch
            {
                ResponseServiceEnum.NOT_FOUND_KEY => "206",
                ResponseServiceEnum.CONNECTION_OS => "500",             
                ResponseServiceEnum.INVALID_KEY_TYPE => "400",
                ResponseServiceEnum.INVALID_KEY_ID => "400",
                ResponseServiceEnum.INVALID_KEY_STATUS => "400",
                ResponseServiceEnum.INVALID_VAULT_NAME => "400",
                ResponseServiceEnum.INVALID_DT_MODIFY => "400",
                ResponseServiceEnum.DIFFERENT_ID => "400",
                ResponseServiceEnum.DIFFERENT_TYPE => "400",
                ResponseServiceEnum.SERVICE_KEY_ERROR=>"400",
                ResponseServiceEnum.SERVICE_ACCOUNT_ERROR => "400",
                ResponseServiceEnum.BAD_REQUEST_JSON => "400",
                ResponseServiceEnum.SERVICE_INTERNAL_ERROR => "500",
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }

        /// <summary>
        /// Obtiene el código de estado del servidor
        /// </summary>
        public static string getMessage(this ResponseServiceEnum responseService)
        {
            return responseService switch
            {
                ResponseServiceEnum.NOT_FOUND_KEY => "La llave que se quiere modificar no se encuentra registrada",
                ResponseServiceEnum.CONNECTION_OS => "No se generó la conexión con open search",
                ResponseServiceEnum.INVALID_KEY_ID => "[key.keyId] la llave no cumple los valores permitidos o el formato requerido.",
                ResponseServiceEnum.INVALID_KEY_TYPE => "[key.keyType] no cumple con los valores de tipo de llave permitidos o el formato requerido.",
                ResponseServiceEnum.INVALID_KEY_STATUS => "[key.keyStatus] no cumple con los valores del estado de la llave permitidos o el formato requerido",
                ResponseServiceEnum.INVALID_VAULT_NAME => "[vaultInsc.vaultName] no cumple con los valores del vault name.",
                ResponseServiceEnum.INVALID_DT_MODIFY => "[effDtKey.effDtModify] no cumple con el formato permitido.",
                ResponseServiceEnum.DIFFERENT_ID => "El número de identificación es diferente al que se encuentra regsitrado",
                ResponseServiceEnum.DIFFERENT_TYPE => "El tipo de documento es difernete al que se encuentra registrado",
                ResponseServiceEnum.SERVICE_KEY_ERROR => "No se pudo modificar llave.",
                ResponseServiceEnum.SERVICE_ACCOUNT_ERROR => "No se pudo modificar el producto.",
                ResponseServiceEnum.BAD_REQUEST_JSON => "Bad request JSON",
                ResponseServiceEnum.SERVICE_INTERNAL_ERROR => "Error interno del servidor",
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }

        /// <summary>
        /// Obtiene la severidad del error
        /// </summary>
        public static int getHttpCode(this ResponseServiceEnum responseService)
        {
            return responseService switch
            {
                ResponseServiceEnum.NOT_FOUND_KEY => 206,
                ResponseServiceEnum.CONNECTION_OS => 500,             
                ResponseServiceEnum.INVALID_KEY_TYPE => 400,
                ResponseServiceEnum.INVALID_KEY_STATUS => 400,                
                ResponseServiceEnum.INVALID_VAULT_NAME => 400,
                ResponseServiceEnum.INVALID_DT_MODIFY => 400,
                ResponseServiceEnum.DIFFERENT_ID => 400,
                ResponseServiceEnum.DIFFERENT_TYPE => 400,
                ResponseServiceEnum.SERVICE_KEY_ERROR => 400,
                ResponseServiceEnum.SERVICE_ACCOUNT_ERROR => 400,
                ResponseServiceEnum.BAD_REQUEST_JSON => 400,
                ResponseServiceEnum.SERVICE_INTERNAL_ERROR => 500,
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }

        
    }
}