using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace domain.models.enrollment
{
    public class InquiryHeaders
    {  
        [JsonPropertyName("apiKey")]
        public string apikey { get; set; }

        
        [JsonPropertyName("Authentication")]
        public string authentication { get; set; }

        
        [JsonPropertyName("uuId")]
        public string uuId { get; set; }

        
        [JsonPropertyName("timeStamps")]
        public string timeStamps { get; set; }

        
        [JsonPropertyName("systemId")]
        public string systemId { get; set; }

        [JsonPropertyName("KeyId")]
        public string keyId { get; set; }

    }
}