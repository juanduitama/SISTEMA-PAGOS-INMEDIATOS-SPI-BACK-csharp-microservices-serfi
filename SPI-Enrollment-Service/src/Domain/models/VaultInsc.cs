using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace domain.models
{
    public class VaultInsc
    {
        [Required]
        [JsonPropertyName("vaultName")]
        public string vaultName { get; set; }

        [Required]
        [JsonPropertyName("flowService")]
        public string flowService { get; set; }

        [Required]
        [JsonPropertyName("vaultId")]
        public long vaultId { get; set; }
    }
}
