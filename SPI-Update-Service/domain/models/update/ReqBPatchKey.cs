using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;
using SPI_Update_Service.domain.models.update;

namespace domain.models
{
    /// <summary>
    /// 
    /// </summary>
    public class ReqBPatchKey
    {
        
        [JsonPropertyName("custInfo")]
        public CustInfoRq custInfo {get; set;}

        [JsonPropertyName("key")]
        public Key key { get; set; }

        [JsonPropertyName("vaultInsc")]
        public VaultInscRq vaultInsc {get; set;}

        [JsonPropertyName("effDtKey")]
        public EffDtKey effDtKey { get; set; }
    }
}
