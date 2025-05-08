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
            key.keyType = updateKey.reqBPatchKey.key.newKeyType;
            key.keyId = updateKey.reqBPatchKey.key.newKeyId;
            key.keyStatus = updateKey.reqBPatchKey.key.newKeyStatus;
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

        public MsgInformationResponseSerfi mapMessageResponse(OSDefinitive osIndexDefinitive, UpdateKeyRq updateKey, MessageInformation messageInformation)
        {
            MsgInformationResponseSerfi msgInformationResponseSerfi = new MsgInformationResponseSerfi();
            Meta meta = new Meta();
            meta.uuid = updateKey.updateHeaders.uuId;
            meta.timeStamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            meta.systemId = "";
            msgInformationResponseSerfi.meta = meta;

            msgInformationResponseSerfi.statusCodigo = messageInformation.msgCode;
            msgInformationResponseSerfi.statusDesc = messageInformation.msgDescription;

            AditionalInfo aditionalInfoItem = new AditionalInfo();
            aditionalInfoItem.codigo = "";
            aditionalInfoItem.detalle = "";


            List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();
            aditionalInfoList.Add(aditionalInfoItem);

            msgInformationResponseSerfi.aditionalInfo = aditionalInfoList;


            Data data = new Data();
            //No siempre se llena este merchantId
            data.merchantId = "";
            msgInformationResponseSerfi.data = data;


            return msgInformationResponseSerfi;
        }

        public MsgInformationResponseSerfi mapMessageResponseAccount(OSDefinitive osIndexDefinitive, UpdateAccountRq updateKey, MessageInformation messageInformation)
        {
            MsgInformationResponseSerfi msgInformationResponseSerfi = new MsgInformationResponseSerfi();
            Meta meta = new Meta();
            meta.uuid = updateKey.updateHeaders.uuId;
            meta.timeStamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            meta.systemId = "";
            msgInformationResponseSerfi.meta = meta;

            msgInformationResponseSerfi.statusCodigo = messageInformation.msgCode;
            msgInformationResponseSerfi.statusDesc = messageInformation.msgDescription;

            AditionalInfo aditionalInfoItem = new AditionalInfo();
            aditionalInfoItem.codigo = "";
            aditionalInfoItem.detalle = "";


            List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();
            aditionalInfoList.Add(aditionalInfoItem);

            msgInformationResponseSerfi.aditionalInfo = aditionalInfoList;


            Data data = new Data();
            //No siempre se llena este merchantId
            data.merchantId = "";
            msgInformationResponseSerfi.data = data;


            return msgInformationResponseSerfi;
        }


        public OSDefinitive mapUpdateAccountOSDefinitiveFromRequest(UpdateAccountRq updateAccount, OSDefinitive oldEntity)
        {
            OSDefinitive osNewIndexDefinitive = new OSDefinitive();

            osNewIndexDefinitive.rqUID = updateAccount.updateHeaders.uuId;

            AcctInfo acctInfo = new AcctInfo();

            acctInfo.acctType = updateAccount.reqBPatchAccount.acctInfo.newAcctType != null ? reqBPatchAccount.acctInfo.newAcctType : osOldDefinitive.acctInfo.acctType;
            acctInfo.acctId = updateAccount.reqBPatchAccount.acctInfo.newAcctId != null ? reqBPatchAccount.acctInfo.newAcctId : osOldDefinitive.acctInfo.acctId;

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
            key.keyType = updateKey.reqBPatchKey.key.newKeyType;
            key.keyId = updateKey.reqBPatchKey.key.newKeyId;
            key.keyStatus = updateKey.reqBPatchKey.key.newKeyStatus;
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
    }

}
