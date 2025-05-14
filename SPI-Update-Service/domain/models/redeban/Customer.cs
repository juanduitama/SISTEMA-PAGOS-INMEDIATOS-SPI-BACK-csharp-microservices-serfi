using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace domain.models.redeban
{
    public class Customer
    {
        /// <summary>
        /// Tipo de persona (PERSON o COMMERCE)
        /// </summary>
        [Required]
        [JsonPropertyName("Type")]
        public string? type { get; set; }





    }
}
