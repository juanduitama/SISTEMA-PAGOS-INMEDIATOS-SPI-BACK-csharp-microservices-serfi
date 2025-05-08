
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using domain.models.enrollment;

namespace application.mapper
{
    public class HeaderSerfiMapper
    {

        public UpdateHeaders mapHeaders(string apiKey, string autentication, string uuId, string timeStamp, string systemId){
            UpdateHeaders headers = new UpdateHeaders();

            headers.apikey = apiKey;
            headers.authentication = autentication;
            headers.uuId = uuId;
            headers.timeStamps = timeStamp;
            headers.systemId = systemId;

            return headers;
        }

    }
}

