using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Enrollment_Service.model
{
    public class MessageInformation
    {
        /**
         * Código de mensaje en la API
         */
        [JsonPropertyName("MsgCode")]
        public string? msgCode { get; set; }

        /**
         * Descripción del mensaje
         */
        [JsonPropertyName("MsgDescription")]
        public string? msgDescription {get;}
    }
}
