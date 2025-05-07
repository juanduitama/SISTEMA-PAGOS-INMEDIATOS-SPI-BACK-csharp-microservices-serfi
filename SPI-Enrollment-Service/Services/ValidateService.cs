using Constants;
using Models.enrollment;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services
{
    public class ValidateService
    {

           
        public bool ValidateServiceModel(EnrollmentRq enrollmentRq) {

            if (!validateAccountType(enrollmentRq.reqBPostAccountRelationship.accountInfo.acctType))
            {
                
            }
            else if (!validateRegex(enrollmentRq.reqBPostAccountRelationship.accountInfo.acctId, ValidationEnums.ACCOUNT_ID))
            {
                
            }
            else if (!validateRegex(enrollmentRq.reqBPostAccountRelationship.custInfo.firstName, ValidationEnums.CUST_INFO_NAMES)
                        && !validateSize(enrollmentRq.reqBPostAccountRelationship.custInfo.firstName, ValidationEnums.CUST_INFO_SIZE_40))
            {

            }
            else if (!validateRegex(enrollmentRq.reqBPostAccountRelationship.custInfo.secondName, ValidationEnums.CUST_INFO_NAMES)
                    && !validateSize(enrollmentRq.reqBPostAccountRelationship.custInfo.secondName, ValidationEnums.CUST_INFO_SIZE_40))
            {

            }
            else if (!validateRegex(enrollmentRq.reqBPostAccountRelationship.custInfo.lastName, ValidationEnums.CUST_INFO_NAMES)
                    && !validateSize(enrollmentRq.reqBPostAccountRelationship.custInfo.lastName, ValidationEnums.CUST_INFO_SIZE_40))
            {

            }
            else if (!validateRegex(enrollmentRq.reqBPostAccountRelationship.custInfo.secondLastName, ValidationEnums.CUST_INFO_NAMES)
                    && !validateSize(enrollmentRq.reqBPostAccountRelationship.custInfo.secondLastName, ValidationEnums.CUST_INFO_SIZE_40))
            {

            }
            else if (!validateRegex(enrollmentRq.reqBPostAccountRelationship.custInfo.custLegalName, ValidationEnums.CUST_INFO_NAMES)
                    && !validateSize(enrollmentRq.reqBPostAccountRelationship.custInfo.custLegalName, ValidationEnums.CUST_INFO_SIZE_140))
            {

            }
            else if (!validateCustType(enrollmentRq.reqBPostAccountRelationship.custInfo.custType))
            {

            }
            else if (!validateIdentType(enrollmentRq.reqBPostAccountRelationship.custInfo.custIdent.custIdentType))
            {

            }
            else if (!validateRegex(enrollmentRq.reqBPostAccountRelationship.custInfo.custIdent.custIdentId,ValidationEnums.IDENT_ID)
                    && !validateSize(enrollmentRq.reqBPostAccountRelationship.custInfo.custIdent.custIdentId, ValidationEnums.IDENT_ID_SIZE))
            {

            }
            else if (!validateKeyType(enrollmentRq.reqBPostAccountRelationship.key.keyType, enrollmentRq.reqBPostAccountRelationship.key.keyId))
            {

            }
            else if (!validateKeyStatus(enrollmentRq.reqBPostAccountRelationship.key.keyStatus))
            {

            }
            else if (!validateDateFormat(enrollmentRq.reqBPostAccountRelationship.effDtKey.effDtCreate)) {
              
            }
            else if (!validateDateFormat(enrollmentRq.reqBPostAccountRelationship.effDtKey.effDtModify))
            {
                //Excepcion
            }
            else if (!validateDateFormat(enrollmentRq.reqBPostAccountRelationship.effDtKey.effDtConsent))
            {
                //Excepcion
            }
            else if (!validateFlowServices(enrollmentRq.reqBPostAccountRelationship.vaultInsc.flowService)) {

            }
            else if (!validateVaultName(enrollmentRq.reqBPostAccountRelationship.vaultInsc.vaultName))
            {

            }

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


        public bool validateCustType(string custType)
        {
            switch (custType)
            {
                case ValidationEnums.CUST_INFO_LEGAL_NAME_PN:
                    return true;
                    break;
                case ValidationEnums.CUST_INFO_LEGAL_NAME_PJ:
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
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
