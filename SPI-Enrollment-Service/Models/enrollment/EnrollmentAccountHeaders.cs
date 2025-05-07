using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.enrollment
{
    public class EnrollmentAccountHeaders
    {
        [Required]
        [JsonPropertyName("apiKey")]
        public string? apikey {get; set; }

        [Required]
        [JsonPropertyName("Authentication")]
        public string? authentication {get; set; }

        [Required]
        [JsonPropertyName("uuId")]
        public string? uuId { get; set; }

        [Required]
        [JsonPropertyName("timeStamps")]
        public string? timeStamps { get; set; }

        [Required]
        [JsonPropertyName("systemId")]
        public string? systemId { get; set; }
    }
}
