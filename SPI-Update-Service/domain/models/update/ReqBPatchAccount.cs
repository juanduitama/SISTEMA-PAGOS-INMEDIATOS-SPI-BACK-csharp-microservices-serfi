using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;

namespace domain.models
{
    /// <summary>
    /// 
    /// </summary>
    public class ReqBPatchAccount
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
