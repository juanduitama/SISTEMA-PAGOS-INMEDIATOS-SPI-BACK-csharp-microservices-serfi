
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using domain.models.enrollment;

namespace application.mapper
{
    public class HeaderSerfiMapper
    {

        public DeleteHeaders mapHeaders(string apiKey, string autentication, string uuId, string timeStamp, string systemId){
            DeleteHeaders headers = new DeleteHeaders();

            headers.apikey = apiKey;
            headers.authentication = autentication;
            headers.uuId = uuId;
            headers.timeStamps = timeStamp;
            headers.systemId = systemId;

            return headers;
        }

    }
}

