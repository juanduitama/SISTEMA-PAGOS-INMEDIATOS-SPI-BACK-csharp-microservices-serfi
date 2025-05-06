using SPI_lambda_consulta.model.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_lambda_consulta.model
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
