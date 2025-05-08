using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using domain.constants;
using domain.models;
using domain.models.enrollment;
using domain.models.redeban.response;

namespace application.mapper
{
    public class ResponseSerfiMapper
    {
        public MsgInformationResponseSerfi responseSuccess(EnrollmentRq request, MessageInformation responseRedeban){
            MsgInformationResponseSerfi response = new MsgInformationResponseSerfi();

            response.meta.uuid = request.enrollmenAccountHeaders.uuId;
            response.meta.timeStamp = request.enrollmenAccountHeaders.timeStamps;
            response.meta.systemId = request.enrollmenAccountHeaders.systemId;
            response.statusCodigo = ResponseEnun.ENRROLLMENT_RESPONSE_CODE_SUCCESS;
            response.statusDesc = ResponseEnun.ENRROLLMENT_RESPONSE_DESC_SUCCESS;

            AditionalInfo aditionalInfo = new AditionalInfo();
            aditionalInfo.codigo = responseRedeban.msgCode;
            aditionalInfo.detalle = responseRedeban.msgDescription;

            response.aditionalInfo.Add(aditionalInfo);

            return response;
        }
    }

}
