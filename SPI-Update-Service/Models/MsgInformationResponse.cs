using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Update_Service.model
{
    public class MsgInformationResponse
    {

        /**
         * Objeto del mensaje de respuesta
         */
        [JsonPropertyName("MessageInformation")]
        public MessageInformation? messageInformation { get; set; }

        /**
         * Representa que hay una lista de tipo Envelope en el cuerpo del mensaje
         */
        [JsonPropertyName("AdditionalData")]
        public AdditionalData? aditionalData { get; set; }
    }
}
