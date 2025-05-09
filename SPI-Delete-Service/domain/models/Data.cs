using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace domain.models
{
    public class Data
    {
        [Required]
        [JsonPropertyName("merchantId")]
        public string merchantId { get; set; }
    }
}
