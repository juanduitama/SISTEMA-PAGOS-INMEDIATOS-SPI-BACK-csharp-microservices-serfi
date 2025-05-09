using domain.constants;
using domain.models;
using domain.models.enrollment;
using domain.models.openSearchModel;
using SPI_Update_Service.domain.models.update;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace application.Services
{
    public class ValidateService
    {

           
        public bool ValidateServiceUpdateKeyModel(UpdateKeyRq updateKey) {

            // Valida custType
            if (!validateCustType(updateKey.reqBPatchKey.custInfo))
            { 
                throw new SerfiException(ResponseServiceEnum.INVALID_TYPE_PERSON.getErrorCode(), ResponseServiceEnum.INVALID_TYPE_PERSON.getMessage() , ResponseServiceEnum.INVALID_TYPE_PERSON.getHttpCode());
            }
            // Valida custIdentType
            else if (!validateIdentType(updateKey.reqBPatchKey.custInfo.custIdent.custIdentType))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_TYPE_ID.getErrorCode(), ResponseServiceEnum.INVALID_TYPE_ID.getMessage() , ResponseServiceEnum.INVALID_TYPE_ID.getHttpCode());
            }
            // Valida custIdent Id
            else if (!validateRegex(updateKey.reqBPatchKey.custInfo.custIdent.custIdentId,ValidationEnums.IDENT_ID)
                    && !validateSize(updateKey.reqBPatchKey.custInfo.custIdent.custIdentId, ValidationEnums.IDENT_ID_SIZE))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_ID.getErrorCode(), ResponseServiceEnum.INVALID_ID.getMessage(), ResponseServiceEnum.INVALID_ID.getHttpCode());
            }
            // Valida oldKey
            else if (!validateKeyType(updateKey.reqBPatchKey.key.oldKeyType, updateKey.reqBPatchKey.key.oldKeyId, ConstantsEnum.TYPE_OLD_KEY_ID))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_OLD_KEY_TYPE.getErrorCode(), ResponseServiceEnum.INVALID_OLD_KEY_TYPE.getMessage(), ResponseServiceEnum.INVALID_OLD_KEY_TYPE.getHttpCode());
            }
            // Valida newKey
            else if (!validateKeyType(updateKey.reqBPatchKey.key.newKeyType, updateKey.reqBPatchKey.key.newKeyId, ConstantsEnum.TYPE_NEW_KEY_ID))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_NEW_KEY_TYPE.getErrorCode(), ResponseServiceEnum.INVALID_NEW_KEY_TYPE.getMessage(), ResponseServiceEnum.INVALID_NEW_KEY_TYPE.getHttpCode());
            }
            // Valida newKeyStatus
            else if (!validateKeyStatus(updateKey.reqBPatchKey.key.newKeyStatus))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_NEW_KEY_STATUS.getErrorCode(), ResponseServiceEnum.INVALID_NEW_KEY_STATUS.getMessage(), ResponseServiceEnum.INVALID_NEW_KEY_STATUS.getHttpCode());
            }
            // Valida oldKeyStatus
            else if (!validateKeyStatus(updateKey.reqBPatchKey.key.oldKeyStatus))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_OLD_KEY_STATUS.getErrorCode(), ResponseServiceEnum.INVALID_OLD_KEY_STATUS.getMessage(), ResponseServiceEnum.INVALID_OLD_KEY_STATUS.getHttpCode());
            }
            // Valida effDtModify
            else if (!validateDateFormat(updateKey.reqBPatchKey.effDtKey.effDtModify))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_DT_MODIFY.getErrorCode(), ResponseServiceEnum.INVALID_DT_MODIFY.getMessage(), ResponseServiceEnum.INVALID_DT_MODIFY.getHttpCode());
            }
            // Valida el vaultNAme
            else if (!validateVaultName(updateKey.reqBPatchKey.vaultInsc.vaultName))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_VAULT_NAME.getErrorCode(), ResponseServiceEnum.INVALID_VAULT_NAME.getMessage(), ResponseServiceEnum.INVALID_VAULT_NAME.getHttpCode());
            }
            Console.WriteLine("validacion Exitosa Key Update");
            return true;
        }


        public bool ValidateServiceUpdateKeyModel(UpdateAccountRq updateAccount)
        {

            //Validaciones oldAcctType
             if (!validateAccountType(updateAccount.reqBPatchAccount.acctInfo.oldAcctType))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_ACCTYPE.getErrorCode(), ResponseServiceEnum.INVALID_ACCTYPE.getMessage(), ResponseServiceEnum.INVALID_ACCTYPE.getHttpCode());
            }
            //Validaciones oldAcctId
            else if (!validateRegex(updateAccount.reqBPatchAccount.acctInfo.oldAcctId, ValidationEnums.ACCOUNT_ID))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_ACCTID.getErrorCode(), ResponseServiceEnum.INVALID_ACCTID.getMessage(), ResponseServiceEnum.INVALID_ACCTYPE.getHttpCode());
            }

            //Validaciones newAcctType
            if (!validateAccountType(updateAccount.reqBPatchAccount.acctInfo.newAcctType))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_NEW_ACCTYPE.getErrorCode(), ResponseServiceEnum.INVALID_NEW_ACCTYPE.getMessage() , ResponseServiceEnum.INVALID_NEW_ACCTYPE.getHttpCode());
            }
            //Validaciones newAcctId
            else if (!validateRegex(updateAccount.reqBPatchAccount.acctInfo.newAcctId, ValidationEnums.ACCOUNT_ID))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_NEW_ACCTID.getErrorCode(), ResponseServiceEnum.INVALID_NEW_ACCTID.getMessage(), ResponseServiceEnum.INVALID_NEW_ACCTID.getHttpCode());
            }

            //Validaciones Objeto CustType
            else if (!validateCustType(updateAccount.reqBPatchAccount.custInfo))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_TYPE_PERSON.getErrorCode(), ResponseServiceEnum.INVALID_TYPE_PERSON.getMessage(), ResponseServiceEnum.INVALID_TYPE_PERSON.getHttpCode());
            }
             //Validaciones objeto CustIdent
            else if (!validateIdentType(updateAccount.reqBPatchAccount.custInfo.custIdent.custIdentType))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_TYPE_ID.getErrorCode(), ResponseServiceEnum.INVALID_TYPE_ID.getMessage(), ResponseServiceEnum.INVALID_TYPE_ID.getHttpCode());
            }
            // Validaciones custIdent
            else if (!validateRegex(updateAccount.reqBPatchAccount.custInfo.custIdent.custIdentId, ValidationEnums.IDENT_ID)
                    && !validateSize(updateAccount.reqBPatchAccount.custInfo.custIdent.custIdentId, ValidationEnums.IDENT_ID_SIZE))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_ID.getErrorCode(), ResponseServiceEnum.INVALID_ID.getMessage(), ResponseServiceEnum.INVALID_ID.getHttpCode());
            }
            //Validaciones VaultInsc VaultName
            else if (!validateVaultName(updateAccount.reqBPatchAccount.vaultInsc.vaultName))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_VAULT_NAME.getErrorCode(), ResponseServiceEnum.INVALID_VAULT_NAME.getMessage(), ResponseServiceEnum.INVALID_VAULT_NAME.getHttpCode());
            }
            //Validaciones Fecha EffDtModify
            else if (!validateDateFormat(updateAccount.reqBPatchAccount.effDtKey.effDtModify))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_DT_MODIFY.getErrorCode(), ResponseServiceEnum.INVALID_DT_MODIFY.getMessage(), ResponseServiceEnum.INVALID_DT_MODIFY.getHttpCode());
            }

            Console.WriteLine("validacion Exitosa Account Update");
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


        public bool validateCustType(CustInfoRq custInfo)
        {
            if (custInfo.custType.Equals(ValidationEnums.CUST_INFO_LEGAL_NAME_PN))
            {
                return false;

            }
            else if (custInfo.custType.Equals(ValidationEnums.CUST_INFO_LEGAL_NAME_PJ))
            {
                return false;
            }
            return true;
        }
        public bool validateCustType(CustInfo custInfo)
        {
            if (custInfo.custType.Equals(ValidationEnums.CUST_INFO_LEGAL_NAME_PN))
            {
                return false;

            }
            else if (custInfo.custType.Equals(ValidationEnums.CUST_INFO_LEGAL_NAME_PJ))
            {
                return false;
            }
            return true;
        }

        public bool validateKeyType(string keyType, string value, int type){
            switch (keyType)
            {
                case ValidationEnums.KEY_TYPE_IDENT:
                    if(!validateRegex(value, ValidationEnums.KEY_ID_IDENT)){
                        if(type == 0){
                            throw new SerfiException(ResponseServiceEnum.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_KEY_ID.getHttpCode());
                        }else if( type == 1){
                             throw new SerfiException(ResponseServiceEnum.INVALID_OLD_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_OLD_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_OLD_KEY_ID.getHttpCode());
                        }else{
                             throw new SerfiException(ResponseServiceEnum.INVALID_NEW_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_NEW_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_NEW_KEY_ID.getHttpCode());
                        }
                        return false;
                    }else{
                        return true;
                    }
                    break;
                case ValidationEnums.KEY_TYPE_CEL:
                    if(!validateRegex(value, ValidationEnums.KEY_ID_CEL)){
                        if(type == 0){
                            throw new SerfiException(ResponseServiceEnum.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_KEY_ID.getHttpCode());
                        }else if( type == 1){
                             throw new SerfiException(ResponseServiceEnum.INVALID_OLD_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_OLD_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_OLD_KEY_ID.getHttpCode());
                        }else{
                             throw new SerfiException(ResponseServiceEnum.INVALID_NEW_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_NEW_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_NEW_KEY_ID.getHttpCode());
                        }
                        return false;
                    }else{
                        return true;
                    }
                    break;
                case ValidationEnums.KEY_TYPE_EMAIL:
                    if(!validateRegex(value, ValidationEnums.KEY_ID_EMAIL)){
                        if(type == 0){
                            throw new SerfiException(ResponseServiceEnum.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_KEY_ID.getHttpCode());
                        }else if( type == 1){
                             throw new SerfiException(ResponseServiceEnum.INVALID_OLD_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_OLD_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_OLD_KEY_ID.getHttpCode());
                        }else{
                             throw new SerfiException(ResponseServiceEnum.INVALID_NEW_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_NEW_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_NEW_KEY_ID.getHttpCode());
                        }
                        return false;
                    }else{
                        return true;
                    }
                    break;
                case ValidationEnums.KEY_TYPE_ALIAS:
                    if(!validateRegex(value, ValidationEnums.KEY_ID_ALIAS)){
                        if(type == 0){
                            throw new SerfiException(ResponseServiceEnum.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_KEY_ID.getHttpCode());
                        }else if( type == 1){
                             throw new SerfiException(ResponseServiceEnum.INVALID_OLD_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_OLD_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_OLD_KEY_ID.getHttpCode());
                        }else{
                             throw new SerfiException(ResponseServiceEnum.INVALID_NEW_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_NEW_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_NEW_KEY_ID.getHttpCode());
                        }
                        return false;
                    }else{
                        return true;
                    }
                    break;
                case ValidationEnums.KEY_TYPE_MERCH:
                    if(!validateRegex(value, ValidationEnums.KEY_ID_MERCH)){
                        if(type == 0){
                            throw new SerfiException(ResponseServiceEnum.INVALID_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_KEY_ID.getHttpCode());
                        }else if( type == 1){
                             throw new SerfiException(ResponseServiceEnum.INVALID_OLD_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_OLD_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_OLD_KEY_ID.getHttpCode());
                        }else{
                             throw new SerfiException(ResponseServiceEnum.INVALID_NEW_KEY_ID.getErrorCode(), ResponseServiceEnum.INVALID_NEW_KEY_ID.getMessage(), ResponseServiceEnum.INVALID_NEW_KEY_ID.getHttpCode());
                        }
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
            switch (keyStatus.ToUpper()) {
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

        public bool validateOldStatus(string status){
            return status.ToUpper().Equals(ValidationEnums.KEY_ACTIVE_STATUS) ? true : false;
        }

        public bool validateSameId(UpdateKeyRq request, OSDefinitive entity){
            return request.reqBPatchKey.custInfo.custIdent.custIdentId.Equals(entity.custInfoOS.custIdent.custIdentId) ? true : false;
        }

        public bool validateSameId(UpdateAccountRq request, OSDefinitive entity)
        {
            return request.reqBPatchAccount.custInfo.custIdent.custIdentId.Equals(entity.custInfoOS.custIdent.custIdentId) ? true : false;
        }

        public bool validateSameIdType(UpdateKeyRq request, OSDefinitive entity){
            return request.reqBPatchKey.custInfo.custIdent.custIdentType.Equals(entity.custInfoOS.custIdent.custIdentType) ? true : false;
        }

        public bool validateSameIdType(UpdateAccountRq request, OSDefinitive entity)
        {
            return request.reqBPatchAccount.custInfo.custIdent.custIdentType.Equals(entity.custInfoOS.custIdent.custIdentType) ? true : false;
        }

        public void validateOSEntity(UpdateKeyRq request, OSDefinitive opSearchEntity){
            if (opSearchEntity == null){
                    throw new SerfiException(ResponseServiceEnum.NOT_FOUND_KEY.getErrorCode(), ResponseServiceEnum.NOT_FOUND_KEY.getMessage(), ResponseServiceEnum.NOT_FOUND_KEY.getHttpCode());
                }else if(!validateOldStatus(opSearchEntity.key.oldKeyStatus)){
                    throw new SerfiException(ResponseServiceEnum.INVALID_KEY_STATUS.getErrorCode(), ResponseServiceEnum.INVALID_KEY_STATUS.getMessage(), ResponseServiceEnum.INVALID_KEY_STATUS.getHttpCode());
                }else if (!validateSameId(request,opSearchEntity)){
                    throw new SerfiException(ResponseServiceEnum.DIFFERENT_ID.getErrorCode(), ResponseServiceEnum.DIFFERENT_ID.getMessage(), ResponseServiceEnum.DIFFERENT_ID.getHttpCode());
                }else if(!validateSameIdType(request,opSearchEntity)){
                    throw new SerfiException(ResponseServiceEnum.DIFFERENT_TYPE.getErrorCode(), ResponseServiceEnum.DIFFERENT_TYPE.getMessage(), ResponseServiceEnum.DIFFERENT_TYPE.getHttpCode());
                }
        }

        public void validateOSEntityAccount(UpdateAccountRq request, OSDefinitive opSearchEntity)
        {
            if (opSearchEntity == null)
            {
                throw new SerfiException(ResponseServiceEnum.NOT_FOUND_KEY.getErrorCode(), ResponseServiceEnum.NOT_FOUND_KEY.getMessage(), ResponseServiceEnum.NOT_FOUND_KEY.getHttpCode());
            }
            else if (!validateOldStatus(opSearchEntity.key.oldKeyStatus))
            {
                throw new SerfiException(ResponseServiceEnum.INVALID_KEY_STATUS.getErrorCode(), ResponseServiceEnum.INVALID_KEY_STATUS.getMessage(), ResponseServiceEnum.INVALID_KEY_STATUS.getHttpCode());
            }
            else if (!validateSameId(request, opSearchEntity))
            {
                throw new SerfiException(ResponseServiceEnum.DIFFERENT_ID.getErrorCode(), ResponseServiceEnum.DIFFERENT_ID.getMessage(), ResponseServiceEnum.DIFFERENT_ID.getHttpCode());
            }
            else if (!validateSameIdType(request, opSearchEntity))
            {
                throw new SerfiException(ResponseServiceEnum.DIFFERENT_TYPE.getErrorCode(), ResponseServiceEnum.DIFFERENT_TYPE.getMessage(), ResponseServiceEnum.DIFFERENT_TYPE.getHttpCode());
            }
        }

    }


}
