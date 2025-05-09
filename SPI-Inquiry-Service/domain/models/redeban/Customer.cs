using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace domain.models.redeban
{
    public class Customer
    {
        /// <summary>
        /// Tipo de llave del cliente
        /// </summary>
        [Required]
        [JsonPropertyName("Type")]
        public string? custType { get; set; }

        /// <summary>
        /// Valor de la llave del cliente
        /// </summary>
        [Required]
        [JsonPropertyName("SubType")]
        public string? subType { get; set; }

        /// <summary>
        /// Tipo de persona (PERSON o COMMERCE)
        /// </summary>
        [Required]
        [JsonPropertyName("Name")]
        public string? name  { get; set; }




    }
}
