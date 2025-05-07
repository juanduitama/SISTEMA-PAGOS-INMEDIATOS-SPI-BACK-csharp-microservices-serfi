using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Enrollment_Service.model
{
    public class AcctInfo
    {
        /// <summary>
        /// Tipo de cuenta
        /// </summary>
        [JsonPropertyName("acctType")]
        [Required]
        public string acctType { get; set; }

        /// <summary>
        /// Identificador de la cuenta
        /// </summary>
        [JsonPropertyName("acctId")]
        [Required]
        public string acctId { get; set; }
    }
}
