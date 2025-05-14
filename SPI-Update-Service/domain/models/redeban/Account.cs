using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace domain.models.redeban
{
    public class Account
    {

        /// <summary>
        /// Tipo de cuenta.
        /// </summary>
        [JsonPropertyName("TypeAccount")]
        public string typeAccount { get; set; }

        /// <summary>
        /// Número de cuenta.
        /// </summary>
        [JsonPropertyName("AccountNo")]
        public string accountNo { get; set; }

        /// <summary>
        /// Número de cuenta.
        /// </summary>
        [JsonPropertyName("AgeAccount")]
        public string ageAccount { get; set; }
    }
}
