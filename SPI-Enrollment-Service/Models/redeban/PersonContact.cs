using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Enrollment_Service.Models.redeban
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
        [Required]
        [JsonPropertyName("MobileNumber")]
        public string? mobileNumber {get; set;}

        /**
         * Correo electronico
         */
        [Required]
        [JsonPropertyName("Email")]
        public string? email {get; set;}
    }
}
