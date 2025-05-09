using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SPI_Inquiry_Service.domain.models
{
    public class Identification
    {
        [JsonPropertyName("Type")]
        [Required]
        public string docType { get; set; }

        [JsonPropertyName("Number")]
        [Required]
        public string docNumber { get; set; }
    }
}
