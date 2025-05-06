using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_lambda_consulta.model.model
{
    public class Envelope
    {
        /**
         * Línea de tiempo del mensaje de respuesta
         */
        [JsonPropertyName("R101")]
        public string? r101 { get; set; }

        /**
         * Línea de tiempo del mensaje de respuesta
         */
        [JsonPropertyName("R103")]
        public string? r103 { get; set; }

        /**
         * Línea de tiempo del mensaje de respuesta
         */
        [JsonPropertyName("R201")]
        public string? r201 { get; set; }

        /**
         * Línea de tiempo del mensaje de respuesta
         */
        [JsonPropertyName("R203")]
        public string? r203 { get; set; }

        /**
         * Línea de tiempo del mensaje de respuesta
         */
        [JsonPropertyName("R301")]
        public string? r301 { get; set; }

        /**
         * Línea de tiempo del mensaje de respuesta
         */
        [JsonPropertyName("R303")]
        public string? r303 { get; set; }

        /**
         * Línea de tiempo del mensaje de respuesta
         */
        [JsonPropertyName("R205")]
        public string? r205 { get; set; }

        /**
         * Línea de tiempo del mensaje de respuesta
         */
        [JsonPropertyName("R207")]
        public string? r207 { get; set; }
    }
}
