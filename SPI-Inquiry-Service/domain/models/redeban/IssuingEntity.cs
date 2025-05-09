using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SPI_Inquiry_Service.domain.models
{
    public class IssuingEntity
    {
        [JsonPropertyName("NIT")]
        public string? nit { get; set; }


        [JsonPropertyName("FIID")]
        public string? fiid { get; set; }

        [JsonPropertyName("NameEntity")]
        public string? nameEntity { get; set; }
    }
}
