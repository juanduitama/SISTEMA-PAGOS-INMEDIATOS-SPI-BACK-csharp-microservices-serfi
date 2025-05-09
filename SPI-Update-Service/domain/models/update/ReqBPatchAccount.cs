using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace domain.models
{
    /// <summary>
    /// 
    /// </summary>
    public class ReqBPatchAccount
    {
        [ValidateNever]
        [JsonPropertyName("acctInfo")]
        public AcctInfo acctInfo { get; set; }

        
        [JsonPropertyName("custInfo")]
        public CustInfo custInfo { get; set; }

        
        [ValidateNever]
        [JsonPropertyName("key")]
        public Key key { get; set; }

        [ValidateNever]
        [JsonPropertyName("vaultInsc")]
        public VaultInsc vaultInsc { get; set; }

        
        [JsonPropertyName("effDtKey")]
        public EffDtKey? effDtKey { get; set; }

    }
}
