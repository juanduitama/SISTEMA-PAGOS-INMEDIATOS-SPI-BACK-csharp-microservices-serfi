using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Update_Service.model
{
    public class PersonContact
    {
        /**
         * Información de dirección y ubicación del cliente
         */
        [JsonPropertyName("PostalAddress")]
        public PostalAddress? postalAddress {get; set;}

        /**
         * Numero de celular
         */
        [JsonPropertyName("MobileNumber")]
        public string? mobileNumber {get; set;}

        /**
         * Correo electronico
         */
        [JsonPropertyName("Email")]
        public string? email {get; set;}
    }
}
