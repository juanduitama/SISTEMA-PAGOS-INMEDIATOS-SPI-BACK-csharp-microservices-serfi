using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using domain.models;
using domain.models.enrollment;
using domain.models.openSearchModel;
using domain.models.redeban.response;
using SPI_Update_Service.domain.models;
using domain.constants;
using SPI_Update_Service.domain.models.redeban;

namespace application.mapper
{
    /// <summary>
    /// Utilidad para manejar encabezados HTTP
    /// </summary>
    public class RqMapperOs
    {

        private static readonly Random random = new Random();

        public RqMapperOs()
        {
        }

        //Cabeceras de OS a Redeban
        public OSDefinitive mapUpdateKeyOSDefinitiveFromRequest(UpdateKeyRq updateKey, OSDefinitive oldEntity)
        {
            OSDefinitive osNewIndexDefinitive = new OSDefinitive();

            osNewIndexDefinitive.rqUID = updateKey.updateHeaders.uuId;

            AcctInfo acctInfo = new AcctInfo();

            acctInfo.acctType = oldEntity.acctInfo.acctType;
            acctInfo.acctId = oldEntity.acctInfo.acctId;

            osNewIndexDefinitive.acctInfo = acctInfo;

            CustInfoOS custInfoOS = new CustInfoOS();
            custInfoOS.firstName = oldEntity.custInfoOS.firstName;
            custInfoOS.secondName = oldEntity.custInfoOS.secondName;
            custInfoOS.lastName = oldEntity.custInfoOS.lastName;
            custInfoOS.secondLastName = oldEntity.custInfoOS.secondLastName;
            custInfoOS.custLegalName = oldEntity.custInfoOS.custLegalName;
            custInfoOS.custType = oldEntity.custInfoOS.custType;

            CustIdent custIdent = new CustIdent();
            custIdent.custIdentType = oldEntity.custInfoOS.custIdent.custIdentType;
            custIdent.custIdentId = oldEntity.custInfoOS.custIdent.custIdentId;

            custInfoOS.custIdent = custIdent;

            CustContact custContact = new CustContact();
            custContact.custMobileNumber = oldEntity.custInfoOS.custContact.custMobileNumber;
            custContact.custEmail = oldEntity.custInfoOS.custContact.custEmail;

            custInfoOS.custContact = custContact;

            osNewIndexDefinitive.custInfoOS = custInfoOS;      

            Key key = new Key();
            key.keyType = updateKey.reqBPatchKey.key.newKeyType != null ? updateKey.reqBPatchKey.key.newKeyType : oldEntity.key.keyType;
            key.keyId = updateKey.reqBPatchKey.key.newKeyId != null ? updateKey.reqBPatchKey.key.newKeyId : oldEntity.key.keyId;
            key.keyStatus = updateKey.reqBPatchKey.key.newKeyStatus != null ?  updateKey.reqBPatchKey.key.newKeyStatus : oldEntity.key.keyStatus;
            osNewIndexDefinitive.key = key;

            VaultInsc vaultInsc = new VaultInsc();
            vaultInsc.vaultName = updateKey.reqBPatchKey.vaultInsc.vaultName;
            vaultInsc.flowService = ValidationEnums.FLOW_SERVICES_CREATE;
            vaultInsc.vaultId = oldEntity.vaultInsc.vaultId;
            osNewIndexDefinitive.vaultInsc = vaultInsc;

            osNewIndexDefinitive.effDtCreate = oldEntity.effDtCreate;
            osNewIndexDefinitive.effDtModify = updateKey.reqBPatchKey.effDtKey.effDtModify;
            return osNewIndexDefinitive;
        }

        


        public OSDefinitive mapUpdateAccountOSDefinitiveFromRequest(UpdateAccountRq updateAccount, OSDefinitive oldEntity)
        {
            OSDefinitive osNewIndexDefinitive = new OSDefinitive();

            osNewIndexDefinitive.rqUID = updateAccount.updateHeaders.uuId;

            AcctInfo acctInfo = new AcctInfo();

            acctInfo.acctType = updateAccount.reqBPatchAccount.acctInfo.newAcctType != null ? updateAccount.reqBPatchAccount.acctInfo.newAcctType : oldEntity.acctInfo.acctType;
            acctInfo.acctId = updateAccount.reqBPatchAccount.acctInfo.newAcctId != null ? updateAccount.reqBPatchAccount.acctInfo.newAcctId : oldEntity.acctInfo.acctId;

            osNewIndexDefinitive.acctInfo = acctInfo;

            CustInfoOS custInfoOS = new CustInfoOS();
            custInfoOS.firstName = oldEntity.custInfoOS.firstName;
            custInfoOS.secondName = oldEntity.custInfoOS.secondName;
            custInfoOS.lastName = oldEntity.custInfoOS.lastName;
            custInfoOS.secondLastName = oldEntity.custInfoOS.secondLastName;
            custInfoOS.custLegalName = oldEntity.custInfoOS.custLegalName;
            custInfoOS.custType = oldEntity.custInfoOS.custType;

            CustIdent custIdent = new CustIdent();
            custIdent.custIdentType = oldEntity.custInfoOS.custIdent.custIdentType;
            custIdent.custIdentId = oldEntity.custInfoOS.custIdent.custIdentId;

            custInfoOS.custIdent = custIdent;

            CustContact custContact = new CustContact();
            custContact.custMobileNumber = oldEntity.custInfoOS.custContact.custMobileNumber;
            custContact.custEmail = oldEntity.custInfoOS.custContact.custEmail;

            custInfoOS.custContact = custContact;

            osNewIndexDefinitive.custInfoOS = custInfoOS;

            Key key = new Key();
            key.keyType = updateAccount.reqBPatchAccount.key.keyType;
            key.keyId = updateAccount.reqBPatchAccount.key.keyId;
            key.keyStatus = updateAccount.reqBPatchAccount.key.keyStatus != null ? updateAccount.reqBPatchAccount.key.keyStatus: oldEntity.key.keyStatus;
            osNewIndexDefinitive.key = key;

            VaultInsc vaultInsc = new VaultInsc();
            vaultInsc.vaultName = updateAccount.reqBPatchAccount.vaultInsc.vaultName;
            vaultInsc.flowService = ValidationEnums.FLOW_SERVICES_CREATE;
            vaultInsc.vaultId = oldEntity.vaultInsc.vaultId;
            osNewIndexDefinitive.vaultInsc = vaultInsc;

            osNewIndexDefinitive.effDtCreate = oldEntity.effDtCreate;
            osNewIndexDefinitive.effDtModify = updateAccount.reqBPatchAccount.effDtKey.effDtModify;
            return osNewIndexDefinitive;
        }
    }

}
