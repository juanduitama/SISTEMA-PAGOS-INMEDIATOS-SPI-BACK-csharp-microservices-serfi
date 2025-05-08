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
        FOUND_KEY,
        CONNECTION_OS,
        INVALID_ACCTYPE,
        INVALID_ACCTID,
        INVALID_FIRST_NAME,
        INVALID_SECOND_NAME,
        INVALID_LAST_NAME,
        INVALID_SECOND_LAST_NAME,
        INVALID_LEGAL_NAME,
        LEGAL_NAME_NULL,
        INVALID_TYPE_PERSON,
        INVALID_TYPE_ID,
        INVALID_ID,
        INVALID_KEY_TYPE,
        INVALID_KEY_STATUS,
        INVALID_DT_CREATE,
        INVALID_DT_MODIFY,
        INVALID_DT_CONSENT,
        INVALID_FLOW_SERVICES,
        INVALID_VAULT_NAME,

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
                ResponseServiceEnum.FOUND_KEY => "206",
                ResponseServiceEnum.CONNECTION_OS => "500",
                ResponseServiceEnum.INVALID_ACCTYPE => "400",
                ResponseServiceEnum.INVALID_ACCTID => "400",
                ResponseServiceEnum.INVALID_FIRST_NAME => "400",
                ResponseServiceEnum.INVALID_SECOND_NAME => "400",
                ResponseServiceEnum.INVALID_LAST_NAME => "400",
                ResponseServiceEnum.INVALID_SECOND_LAST_NAME => "400",
                ResponseServiceEnum.INVALID_LEGAL_NAME => "400",
                ResponseServiceEnum.LEGAL_NAME_NULL => "400",
                ResponseServiceEnum.INVALID_TYPE_PERSON => "400",
                ResponseServiceEnum.INVALID_TYPE_ID => "400",
                ResponseServiceEnum.INVALID_ID => "400",
                ResponseServiceEnum.INVALID_KEY_TYPE => "400",
                ResponseServiceEnum.INVALID_KEY_STATUS => "400",
                ResponseServiceEnum.INVALID_DT_CREATE => "400",
                ResponseServiceEnum.INVALID_DT_MODIFY => "400",
                ResponseServiceEnum.INVALID_DT_CONSENT => "400",
                ResponseServiceEnum.INVALID_FLOW_SERVICES => "400",
                ResponseServiceEnum.INVALID_VAULT_NAME => "400",
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
                ResponseServiceEnum.FOUND_KEY => "La llave que se quiere crear ya se encuentra registrada",
                ResponseServiceEnum.CONNECTION_OS => "No se generó la conexión con open search",
                ResponseServiceEnum.INVALID_ACCTYPE => "[AcctInfo.acctType] no corresponde a los tipos de cuenta permitidos.",
                ResponseServiceEnum.INVALID_ACCTID => "[ActtInfo.acctId] no corresponde a los valores permitidos como número de cuenta.",
                ResponseServiceEnum.INVALID_FIRST_NAME => "[custInfo.firstName] el primer nombre no cumple com los parámetros establecidos",
                ResponseServiceEnum.INVALID_SECOND_NAME => "[custInfo.secondName] el seg nombre no cumple com los parámetros establecidos",
                ResponseServiceEnum.INVALID_LAST_NAME => "[custInfo.lastName] el primer apellido no cumple com los parámetros establecidos",
                ResponseServiceEnum.INVALID_SECOND_LAST_NAME => "[custInfo.secondLastName] el segundo apellido no cumple com los parámetros establecidos",
                ResponseServiceEnum.INVALID_LEGAL_NAME => "[custInfo.legalName] el legalName no cumple com los parámetros establecidos",
                ResponseServiceEnum.LEGAL_NAME_NULL => "[custInfo.legalName] el campo legaName debe estar vacio",
                ResponseServiceEnum.INVALID_TYPE_PERSON => "[custInfo.custType] no cumple con los valores de tipo de personas (PERSON y COMMERCE) y/o no cumplen con los campos obligatorios ",
                ResponseServiceEnum.INVALID_TYPE_ID => "[custInfo.custIdent.custIdentType] no cumple con los valores de tipo de documentos.",
                ResponseServiceEnum.INVALID_ID => "[custInfo.custIdent.custIdentId] no cumple con el formato establecido o supera la longitud permitida.",
                ResponseServiceEnum.INVALID_KEY_TYPE => "[key.keyType] no cumple con los valores de tipo de llave permitidos o el formato requerido.",
                ResponseServiceEnum.INVALID_KEY_STATUS => "[key.keyStatus] no cumple con los valores de tipo de llave permitidos.",
                ResponseServiceEnum.INVALID_DT_CREATE => "[effDtKey.effDtCreate] no cumple con el formato permitido.",
                ResponseServiceEnum.INVALID_DT_MODIFY => "[effDtKey.effDtModify] no cumple con el formato permitido.",
                ResponseServiceEnum.INVALID_DT_CONSENT => "[effDtKey.effDtConsent] no cumple con el formato permitido.",
                ResponseServiceEnum.INVALID_FLOW_SERVICES => "[vaultInsc.flowService] no cumple con los valores de flujo de servicios permitidos.",
                ResponseServiceEnum.INVALID_VAULT_NAME => "[vaultInsc.vaultName] no cumple con los valores del vault name.",
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
                ResponseServiceEnum.FOUND_KEY => 206,
                ResponseServiceEnum.CONNECTION_OS => 500,
                ResponseServiceEnum.INVALID_ACCTYPE => 400,
                ResponseServiceEnum.INVALID_ACCTID => 400,
                ResponseServiceEnum.INVALID_FIRST_NAME => 400,
                ResponseServiceEnum.INVALID_SECOND_NAME => 400,
                ResponseServiceEnum.INVALID_LAST_NAME => 400,
                ResponseServiceEnum.INVALID_SECOND_LAST_NAME => 400,
                ResponseServiceEnum.INVALID_LEGAL_NAME => 400,
                ResponseServiceEnum.LEGAL_NAME_NULL => 400,
                ResponseServiceEnum.INVALID_TYPE_PERSON => 400,
                ResponseServiceEnum.INVALID_TYPE_ID => 400,
                ResponseServiceEnum.INVALID_ID => 400,
                ResponseServiceEnum.INVALID_KEY_TYPE => 400,
                ResponseServiceEnum.INVALID_KEY_STATUS => 400,
                ResponseServiceEnum.INVALID_DT_CREATE => 400,
                ResponseServiceEnum.INVALID_DT_MODIFY => 400,
                ResponseServiceEnum.INVALID_DT_CONSENT => 400,
                ResponseServiceEnum.INVALID_FLOW_SERVICES => 400,
                ResponseServiceEnum.INVALID_VAULT_NAME => 400,
                _ => throw new ArgumentOutOfRangeException(nameof(responseService))
            };
        }

        
    }
}