using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace domain.models.enrollment
{
    public class EnrollmentAccountHeaders
    {  
        [JsonPropertyName("apiKey")]
        public string apikey { get; set; }

        
        [JsonPropertyName("Authentication")] // Changed to lowercase "a"
        public string authentication { get; set; }

        
        [JsonPropertyName("uuId")]
        public string uuId { get; set; }

        
        [JsonPropertyName("timeStamps")]
        public string timeStamps { get; set; }

        
        [JsonPropertyName("systemId")]
        public string systemId { get; set; }
    }
}