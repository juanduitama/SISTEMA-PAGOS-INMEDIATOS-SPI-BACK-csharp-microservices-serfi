using SPI_Update_Service.model.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Update_Service.model
{
    public class TimeStamps
    {

        /**
         *
         */
        [JsonPropertyName("Envelope")]
        public Envelope? envelope { get; set; }
    }
}
