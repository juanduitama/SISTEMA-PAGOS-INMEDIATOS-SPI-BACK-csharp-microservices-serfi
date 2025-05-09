using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace domain.models
{
    public class Data
    {
        [Required]
        [JsonPropertyName("acctInfo")]
        public AcctInfo acctInfo { get; set; }


        [Required]
        [JsonPropertyName("custInfo")]
        public CustInfo custInfo { get; set; }

        [Required]
        [JsonPropertyName("key")]
        public Key key { get; set; }


        [Required]
        [JsonPropertyName("vaultInsc")]
        public VaultInsc vaultInsc { get; set; }

        [Required]
        [JsonPropertyName("effDtKey")]
        public EffDtKey effDtKey { get; set; }

    }
}
