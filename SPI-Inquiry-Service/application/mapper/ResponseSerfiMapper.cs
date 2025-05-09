using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using domain.constants;
using domain.models;
using domain.models.enrollment;
using domain.models.redeban.response;
using domain.models.openSearchModel;

namespace application.mapper
{
    public class ResponseSerfiMapper
    {
        public MsgInformationResponseSerfi mapinquiryKeyToRed(MsgInformationResponse redResponse, InquiryHeaders inquiryHeaders)
        {
            MsgInformationResponseSerfi msgInformationResponseSerfi = new MsgInformationResponseSerfi();
            Meta meta = new Meta();
            meta.uuid = inquiryHeaders.uuId;
            meta.timeStamp = inquiryHeaders.timeStamps;
            meta.systemId = "";
            msgInformationResponseSerfi.meta = meta;

            msgInformationResponseSerfi.statusCodigo = ResponseEnun.INQUIRY_RESPONSE_CODE_SUCCESS;
            msgInformationResponseSerfi.statusDesc = ResponseEnun.INQUIRY_RESPONSE_DESC_SUCCESS;

            AditionalInfo aditionalInfoItem = new AditionalInfo();
            aditionalInfoItem.codigo = "";
            aditionalInfoItem.detalle = "";


            List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();
            aditionalInfoList.Add(aditionalInfoItem);

            msgInformationResponseSerfi.aditionalInfo = aditionalInfoList;


            Data data = new Data();
            
            AcctInfo acctInfo = new AcctInfo();
            acctInfo.acctType = redResponse.paymentMethod.acctType;
            acctInfo.acctId = redResponse.paymentMethod.number;

            data.acctInfo = acctInfo;

            CustIdent custIdent = new CustIdent();
            custIdent.custIdentType = redResponse.identification.docType;
            custIdent.custIdentId = redResponse.identification.docNumber;

            CustInfo custInfo = new CustInfo();
            custInfo.firstName = redResponse.customer.name;
            custInfo.custType = redResponse.customer.custType;

            custInfo.custIdent = custIdent;

            data.custInfo = custInfo;

            Key key = new Key();
            key.keyType = redResponse.key.type;
            key.keyId = redResponse.key.value;
            key.keyStatus = redResponse.key.keystate;

            data.key = key;


            VaultInsc vaultInsc = new VaultInsc();
            vaultInsc.vaultName = ValidationEnums.VAULT_NAME_RBM;
            vaultInsc.vaultId = 0;

            data.vaultInsc = vaultInsc;

            EffDtKey effDtKey = new EffDtKey();
            effDtKey.effDtCreate = redResponse.key.createdDate;
            effDtKey.effDtModify = redResponse.key.updatedDate

            data.effDtKey = effDtKey;

            msgInformationResponseSerfi.data = data;

            return msgInformationResponseSerfi;
        }

        public MsgInformationResponseSerfi mapMessageResponseKey(OSDefinitive osIndexDefinitive, UpdateKeyRq updateKey, MessageInformation messageInformation)
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
    }


}
