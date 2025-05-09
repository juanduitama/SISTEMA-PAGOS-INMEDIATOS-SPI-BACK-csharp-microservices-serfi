using System.Text.Json.Serialization;

namespace SPI_Inquiry_Service.domain.models
{
    public class UpdateKey
    {
        [JsonPropertyName("Type")]
        public string type { get; set; }

        [JsonPropertyName("Value")]
        public string value { get; set; }
      
        [JsonPropertyName("Keystate")]
        public string keystate { get; set; }

        [JsonPropertyName("InstructedAgent")]
        public string instructedAgent { get; set; }

        [JsonPropertyName("DICE")]
        public string dice { get; set; }


        [JsonPropertyName("CreatedDate")]
        public string createdDate { get; set; }


        [JsonPropertyName("UpdatedDate")]
        public string pdatedDate { get; set; }

    }
}
