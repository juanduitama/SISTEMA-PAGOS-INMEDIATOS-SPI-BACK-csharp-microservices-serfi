using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace domain.models
{
    public class AcctInfo
    {
        /// <summary>
        /// Tipo de cuenta
        /// </summary>
        [JsonPropertyName("acctType")]
        public string acctType { get; set; }

        /// <summary>
        /// Identificador de la cuenta
        /// </summary>
        [JsonPropertyName("acctId")]
        public string acctId { get; set; }


        /// <summary>
        /// Tipo de cuenta
        /// </summary>
        [JsonPropertyName("oldAcctType")]
        public string oldAcctType { get; set; }

        /// <summary>
        /// Identificador de la cuenta
        /// </summary>
        [JsonPropertyName("oldAcctId")]
        public string oldAcctId { get; set; }
        /// <summary>
        /// Tipo de cuenta
        /// </summary>
        [JsonPropertyName("newAcctType")]
        public string newAcctType { get; set; }

        /// <summary>
        /// Identificador de la cuenta
        /// </summary>
        [JsonPropertyName("newAcctId")]
        public string newAcctId { get; set; }
    }
}
