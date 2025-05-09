using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using domain.models;
using domain.models.redeban.response;
using SPI_Delete_Service.domain.models.delete;
using domain.constants;

namespace application.mapper
{
    public class ResponseSerfiMapper
    {
        public MsgInformationResponseSerfi mapMessageResponse(DeleteKeyRq request, MessageInformation responseRedeban){

            MsgInformationResponseSerfi response = new MsgInformationResponseSerfi();

            Meta meta = new Meta();
            meta.uuid = request.deleteHeaders.uuId;
            meta.timeStamp = request.deleteHeaders.timeStamps;
            meta.systemId = request.deleteHeaders.systemId;
            response.meta = meta;

            response.statusCodigo = ResponseEnun.ENRROLLMENT_RESPONSE_CODE_SUCCESS;
            response.statusDesc = ResponseEnun.ENRROLLMENT_RESPONSE_DESC_SUCCESS;

            AditionalInfo aditionalInfo = new AditionalInfo();
            aditionalInfo.codigo = responseRedeban.msgCode;
            aditionalInfo.detalle = responseRedeban.msgDescription;

            List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();

            aditionalInfoList.Add(aditionalInfo);

            response.aditionalInfo = aditionalInfoList;

            Data data = new Data();
            data.merchantId = "";
            response.data = data;

            return response;
        }
    }

}
