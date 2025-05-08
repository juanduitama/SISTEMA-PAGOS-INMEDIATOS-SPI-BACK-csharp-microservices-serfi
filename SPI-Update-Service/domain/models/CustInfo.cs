using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace domain.models
{
    public class CustInfo
    {

        [Required]
        [JsonPropertyName("custType")]
        public string custType { get; set; }

        [Required]
        [JsonPropertyName("custIdent")]
        public CustIdent custIdent {  get; set; }

        [Required]
        [JsonPropertyName("custContact")]
        public CustContact custContact { get; set; }

    }
}
