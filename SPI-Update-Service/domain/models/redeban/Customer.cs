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
        [JsonPropertyName("PartySystemIdentifier")]
        public string? partySystemIdentifier { get; set; }

        /// <summary>
        /// Valor de la llave del cliente
        /// </summary>
        [Required]
        [JsonPropertyName("PartyIdentifier")]
        public string? partyIdentifier { get; set; }

        /// <summary>
        /// Tipo de persona (PERSON o COMMERCE)
        /// </summary>
        [Required]
        [JsonPropertyName("Type")]
        public string? type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("Person")]
        public Person? person { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("Commerce")]
        public Commerce? commerce { get; set; }


    }
}
