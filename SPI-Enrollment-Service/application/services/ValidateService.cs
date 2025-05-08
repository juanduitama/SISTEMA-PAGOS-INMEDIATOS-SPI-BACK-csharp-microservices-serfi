using domain.constants;
using domain.models;
using domain.models.enrollment;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace application.Services
{
    public class ValidateService
    {

           
        public bool ValidateServiceModel(EnrollmentRq enrollmentRq) {

            if (!validateAccountType(enrollmentRq.reqBPostAccountRelationship.acctInfo.acctType))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_ACCTYPE.getErrorCode(), ResponseServiceEnum.INVALID_ACCTYPE.getMessage() + "", ResponseServiceEnum.INVALID_ACCTYPE.getHttpCode());
            }
            else if (!validateRegex(enrollmentRq.reqBPostAccountRelationship.acctInfo.acctId, ValidationEnums.ACCOUNT_ID))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_ACCTID.getErrorCode(), ResponseServiceEnum.INVALID_ACCTID.getMessage() + ValidationEnums.ACCOUNT_ID, ResponseServiceEnum.INVALID_ACCTYPE.getHttpCode());
            }            
            else if (!validateCustType(enrollmentRq.reqBPostAccountRelationship.custInfo))
            { 
                throw new SerfiException(ResponseServiceEnum.INVALID_TYPE_PERSON.getErrorCode(), ResponseServiceEnum.INVALID_TYPE_PERSON.getMessage() , ResponseServiceEnum.INVALID_TYPE_PERSON.getHttpCode());
            }
            else if (!validateIdentType(enrollmentRq.reqBPostAccountRelationship.custInfo.custIdent.custIdentType))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_TYPE_ID.getErrorCode(), ResponseServiceEnum.INVALID_TYPE_ID.getMessage() , ResponseServiceEnum.INVALID_TYPE_ID.getHttpCode());
            }
            else if (!validateRegex(enrollmentRq.reqBPostAccountRelationship.custInfo.custIdent.custIdentId,ValidationEnums.IDENT_ID)
                    && !validateSize(enrollmentRq.reqBPostAccountRelationship.custInfo.custIdent.custIdentId, ValidationEnums.IDENT_ID_SIZE))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_ID.getErrorCode(), ResponseServiceEnum.INVALID_ID.getMessage(), ResponseServiceEnum.INVALID_ID.getHttpCode());
            }
            else if (!validateKeyType(enrollmentRq.reqBPostAccountRelationship.key.keyType, enrollmentRq.reqBPostAccountRelationship.key.keyId))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_KEY_TYPE.getErrorCode(), ResponseServiceEnum.INVALID_KEY_TYPE.getMessage(), ResponseServiceEnum.INVALID_KEY_TYPE.getHttpCode());
            }
            else if (!validateKeyStatus(enrollmentRq.reqBPostAccountRelationship.key.keyStatus))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_KEY_STATUS.getErrorCode(), ResponseServiceEnum.INVALID_KEY_STATUS.getMessage(), ResponseServiceEnum.INVALID_KEY_STATUS.getHttpCode());
            }
            else if (!validateDateFormat(enrollmentRq.reqBPostAccountRelationship.effDtKey.effDtCreate)) {
                throw new SerfiException(ResponseServiceEnum.INVALID_DT_CREATE.getErrorCode(), ResponseServiceEnum.INVALID_DT_CREATE.getMessage(), ResponseServiceEnum.INVALID_DT_CREATE.getHttpCode());
            }
            else if (!validateDateFormat(enrollmentRq.reqBPostAccountRelationship.effDtKey.effDtModify))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_DT_MODIFY.getErrorCode(), ResponseServiceEnum.INVALID_DT_MODIFY.getMessage(), ResponseServiceEnum.INVALID_DT_MODIFY.getHttpCode());
            }
            else if (!validateDateFormat(enrollmentRq.reqBPostAccountRelationship.effDtKey.effDtConsent))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_DT_CONSENT.getErrorCode(), ResponseServiceEnum.INVALID_DT_CONSENT.getMessage(), ResponseServiceEnum.INVALID_DT_CONSENT.getHttpCode());
            }
            else if (!validateFlowServices(enrollmentRq.reqBPostAccountRelationship.vaultInsc.flowService)) {
                throw new SerfiException(ResponseServiceEnum.INVALID_FLOW_SERVICES.getErrorCode(), ResponseServiceEnum.INVALID_FLOW_SERVICES.getMessage(), ResponseServiceEnum.INVALID_FLOW_SERVICES.getHttpCode());
            }
            else if (!validateVaultName(enrollmentRq.reqBPostAccountRelationship.vaultInsc.vaultName))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_VAULT_NAME.getErrorCode(), ResponseServiceEnum.INVALID_VAULT_NAME.getMessage(), ResponseServiceEnum.INVALID_VAULT_NAME.getHttpCode());
            }
            Console.WriteLine("validacion Exitosa");
            return true;
        }

        public bool validateAccountType(string accType)
        {
            switch (accType)
            {
                case ValidationEnums.ACCOUNT_TYPE_CAHO:
                    return true;
                    break;
                case ValidationEnums.ACCOUNT_TYPE_CCTE:
                    return true;
                    break;
                case ValidationEnums.ACCOUNT_TYPE_DBMI:
                    return true;
                    break;
                case ValidationEnums.ACCOUNT_TYPE_DBMO:
                    return true;
                    break;
                case ValidationEnums.ACCOUNT_TYPE_DORD:
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
        }

        public bool validateIdentType(string identType)
        {
            switch (identType)
            {
                case ValidationEnums.CUST_IDENT_TYPE_CC:
                    return true;
                    break;
                case ValidationEnums.CUST_IDENT_TYPE_CE:
                    return true;
                    break;
                case ValidationEnums.CUST_IDENT_TYPE_NUIP:
                    return true;
                    break;
                case ValidationEnums.CUST_IDENT_TYPE_NIT:
                    return true;
                    break;
                case ValidationEnums.CUST_IDENT_TYPE_PEP:
                    return true;
                    break;
                case ValidationEnums.CUST_IDENT_TYPE_PAS:
                    return true;
                    break;
                case ValidationEnums.CUST_IDENT_TYPE_TDI:
                    return true;
                    break;    
                default:
                    return false;
                    break;
            }
        }


        public bool validateCustType(CustInfo custInfo)
        {
            if (custInfo.custType.Equals(ValidationEnums.CUST_INFO_LEGAL_NAME_PN))
            {         
                if (!string.IsNullOrEmpty(custInfo.custLegalName)){
                    throw new SerfiException(ResponseServiceEnum.LEGAL_NAME_NULL.getErrorCode(), ResponseServiceEnum.LEGAL_NAME_NULL.getMessage(), ResponseServiceEnum.LEGAL_NAME_NULL.getHttpCode());
                }
                if (string.IsNullOrEmpty(custInfo.firstName)
                || !validateRegex(custInfo.firstName, ValidationEnums.CUST_INFO_NAMES)
                || !validateSize(custInfo.firstName, ValidationEnums.CUST_INFO_SIZE_40))
                {
                    throw new SerfiException(ResponseServiceEnum.INVALID_FIRST_NAME.getErrorCode(), ResponseServiceEnum.INVALID_FIRST_NAME.getMessage() , ResponseServiceEnum.INVALID_FIRST_NAME.getHttpCode());
                }
                else if(!string.IsNullOrEmpty(custInfo.secondName)){
                    if (!validateRegex(custInfo.secondName, ValidationEnums.CUST_INFO_NAMES)
                        || !validateSize(custInfo.secondName, ValidationEnums.CUST_INFO_SIZE_40))
                    {
                        throw new SerfiException(ResponseServiceEnum.INVALID_SECOND_NAME.getErrorCode(), ResponseServiceEnum.INVALID_SECOND_NAME.getMessage() , ResponseServiceEnum.INVALID_SECOND_NAME.getHttpCode());
                    }
                }
                else if (string.IsNullOrEmpty(custInfo.lastName)
                    || !validateRegex(custInfo.lastName, ValidationEnums.CUST_INFO_NAMES)
                    || !validateSize(custInfo.lastName, ValidationEnums.CUST_INFO_SIZE_40))
                {
                throw new SerfiException(ResponseServiceEnum.INVALID_LAST_NAME.getErrorCode(), ResponseServiceEnum.INVALID_LAST_NAME.getMessage(), ResponseServiceEnum.INVALID_LAST_NAME.getHttpCode());
                }
                else if(!string.IsNullOrEmpty(custInfo.secondLastName)){
                    if (!validateRegex(custInfo.secondLastName, ValidationEnums.CUST_INFO_NAMES)
                        || !validateSize(custInfo.secondLastName, ValidationEnums.CUST_INFO_SIZE_40))
                    {
                        throw new SerfiException(ResponseServiceEnum.INVALID_SECOND_LAST_NAME.getErrorCode(), ResponseServiceEnum.INVALID_SECOND_LAST_NAME.getMessage(), ResponseServiceEnum.INVALID_SECOND_LAST_NAME.getHttpCode());
                    }
            }

            }
            else if (custInfo.custType.Equals(ValidationEnums.CUST_INFO_LEGAL_NAME_PJ))
            {
                if (string.IsNullOrEmpty(custInfo.custLegalName)
                    || !validateRegex(custInfo.custLegalName, ValidationEnums.CUST_INFO_NAMES)
                    || !validateSize(custInfo.custLegalName, ValidationEnums.CUST_INFO_SIZE_140))
                {
                    throw new SerfiException(ResponseServiceEnum.INVALID_LEGAL_NAME.getErrorCode(), ResponseServiceEnum.INVALID_LEGAL_NAME.getMessage() , ResponseServiceEnum.INVALID_LEGAL_NAME.getHttpCode());
                }
            }

            return true;
        }

        public bool validateKeyType(string keyType, string value){
            switch (keyType)
            {
                case ValidationEnums.KEY_TYPE_IDENT:
                    if(!validateRegex(value, ValidationEnums.KEY_ID_IDENT)){
                        return false;
                    }else{
                        return true;
                    }
                    break;
                case ValidationEnums.KEY_TYPE_CEL:
                    if(!validateRegex(value, ValidationEnums.KEY_ID_CEL)){
                        return false;
                    }else{
                        return true;
                    }
                    break;
                case ValidationEnums.KEY_TYPE_EMAIL:
                    if(!validateRegex(value, ValidationEnums.KEY_ID_EMAIL)){
                        return false;
                    }else{
                        return true;
                    }
                    break;
                case ValidationEnums.KEY_TYPE_ALIAS:
                    if(!validateRegex(value, ValidationEnums.KEY_ID_ALIAS)){
                        return false;
                    }else{
                        return true;
                    }
                    break;
                case ValidationEnums.KEY_TYPE_MERCH:
                    if(!validateRegex(value, ValidationEnums.KEY_ID_MERCH)){
                        return false;
                    }else{
                        return true;
                    }
                    break;
                default:
                    return false;
                    break;
            }
        }

        public bool validateKeyStatus(string keyStatus) {
            switch (keyStatus) {
                case ValidationEnums.KEY_ACTIVE_STATUS:
                    return true;
                break;
                default:
                    return false;
                break;
            }
        }

        public bool validateVaultName(string vaultName) {
            switch (vaultName) {
                case ValidationEnums.VAULT_NAME_RBM:
                    return true;
                break;
                default:
                    return false;
                break;
            }
        }
        
        public bool validateFlowServices(string flowService) {
            switch (flowService) {
                case ValidationEnums.FLOW_SERVICES_CREATE:
                    return true;
                break;
                default:
                    return false;
                break;
            }
        }

        public bool validateDateFormat(DateTime date) {
            return DateTime.SpecifyKind(date, DateTimeKind.Utc)
                .ToString(ValidationEnums.DATE_FORMAT)
                .EndsWith("Z");
        }

        public bool validateRegex(string value, string regex)
        {
            if (value != null && !Regex.IsMatch(value, regex)){
                return false;
            }

            return true;
        }

        public bool validateSize(string value, string sizeString){
            int size = Convert.ToInt32(sizeString);
            if(value.Length > size){
                return false;
            }
            return true;   
        }


    }
}
