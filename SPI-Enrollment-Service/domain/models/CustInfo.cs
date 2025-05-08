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
        
        [JsonPropertyName("firstName")]
        public string? firstName { get; set; }

        [JsonPropertyName("secondName")]
        public string? secondName { get; set; }

        [JsonPropertyName("lastName")]
        public string? lastName { get; set; }

        [JsonPropertyName("secondLastName")]
        public string? secondLastName { get; set; }

        [JsonPropertyName("custLegalName")]
        public string? custLegalName { get; set; }

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
