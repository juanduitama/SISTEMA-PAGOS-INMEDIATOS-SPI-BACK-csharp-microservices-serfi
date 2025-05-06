using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Delete_Service.model
{
    public class AdditionalData
    {
        /**
         * Representa que hay una lista de tipo Envelope en el cuerpo del mensaje
         */
        [JsonPropertyName("TimeStamps")]
        public TimeStamps? timeStamps { get; set; }
    }
}
