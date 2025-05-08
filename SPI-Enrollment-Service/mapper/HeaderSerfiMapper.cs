
using SPI_Enrollment_Service.constants;
using SPI_Enrollment_Service.model;
using SPI_Enrollment_Serviceconstants;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using SPI_Enrollment_Service.Models.redeban;
using Models.enrollment;

namespace SPI_Enrollment_Service.util
{
    public class HeaderSerfiMapper
    {

        public EnrollmentAccountHeaders mapHeaders(string apiKey, string autentication, string uuId, string timeStamp, string systemId){
            EnrollmentAccountHeaders headers = new EnrollmentAccountHeaders();

            headers.apikey = apiKey;
            headers.authentication = autentication;
            headers.uuId = uuId;
            headers.timeStamps = timeStamp;
            headers.systemId = systemId;

            return headers;
        }

    }
}

