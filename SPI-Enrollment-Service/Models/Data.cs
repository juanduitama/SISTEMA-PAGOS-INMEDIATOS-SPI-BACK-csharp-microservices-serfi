using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Data
    {
        [Required]
        [JsonPropertyName("merchantId")]
        public string merchantId { get; set; }
    }
}
