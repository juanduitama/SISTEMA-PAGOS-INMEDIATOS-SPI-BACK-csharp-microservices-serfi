
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using domain.models.enrollment;

namespace application.mapper
{
    public class HeaderSerfiMapper
    {

        public InquiryHeaders mapInquiryKeyHeaders(string apiKey, string autentication, string uuId, string timeStamp, string systemId, string keyId){
            InquiryHeaders headers = new InquiryHeaders();

            headers.apikey = apiKey;
            headers.authentication = autentication;
            headers.uuId = uuId;
            headers.timeStamps = timeStamp;
            headers.systemId = systemId;
            headers.keyId = keyId;

            return headers;
        }

    }
}

