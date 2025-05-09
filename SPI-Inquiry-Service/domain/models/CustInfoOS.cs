using domain.models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SPI_Update_Service.domain.models
{
    public class CustInfoOS
    {
        [JsonPropertyName("firstName")]
        public string? firstName { get; set; }

        [JsonPropertyName("secondName")]
        public string? secondName { get; set; }

        [JsonPropertyName("lastName")]
        public string? lastName { get; set; }

        [JsonPropertyName("secondLastName")]
        public string? secondLastName { get; set; }

        [JsonPropertyName("custLegalName")]
        public string? custLegalName { get; set; }

        [Required]
        [JsonPropertyName("custType")]
        public string custType { get; set; }

        [Required]
        [JsonPropertyName("custIdent")]
        public CustIdent custIdent { get; set; }

        [Required]
        [JsonPropertyName("custContact")]
        public CustContact custContact { get; set; }
    }
}
