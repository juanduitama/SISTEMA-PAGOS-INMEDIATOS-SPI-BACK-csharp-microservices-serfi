using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SPI_Update_Service.domain.models.update
{
    public class VaultInscRq
    {
        [Required]
        [JsonPropertyName("vaultName")]
        public string vaultName { get; set; }
    }
}
