using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_lambda_consulta.model
{
    public class PostalAddress
    {

        /**
         * Información que localiza e identifica una dirección específica
         */
        [JsonPropertyName("Address")]
        public string? address;

        /**
         * Identificador formado por un grupo de letras y/o números que se añade a una dirección postal
         */
        [JsonPropertyName("PostalCode")]
        public string? postalCode;

        /**
         * Código de la Ciudad según el DANE
         */
        [JsonPropertyName("DaneCode")]
        public string? daneCode;

        /**
         * Nombre de un área rural, ciudad, municipio
         */
        [JsonPropertyName("TownName")]
        public string? townName;

        /**
         * País
         */
        [JsonPropertyName("Country")]
        public string? country;
    }
}
