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
