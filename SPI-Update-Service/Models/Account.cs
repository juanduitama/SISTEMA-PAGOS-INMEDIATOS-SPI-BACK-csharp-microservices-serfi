using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Update_Service.model
{
    public class Account
    {
        /// <summary>
        /// Identificador del banco.
        /// </summary>
        [JsonPropertyName("BankId")]
        public string BankId { get; set; }

        /// <summary>
        /// Tipo de cuenta.
        /// </summary>
        [JsonPropertyName("TypeAccount")]
        public string TypeAccount { get; set; }

        /// <summary>
        /// Número de cuenta.
        /// </summary>
        [JsonPropertyName("AccountNo")]
        public string AccountNo { get; set; }

        /// <summary>
        /// Número de cuenta.
        /// </summary>
        [JsonPropertyName("AgeAccount")]
        public string ageAccount { get; set; }
    }
}
