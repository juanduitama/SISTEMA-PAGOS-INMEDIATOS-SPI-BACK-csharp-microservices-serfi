using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Delete_Service.model.enterprise
{
    public class ContactInfo
    {
        /**
        * Numero de telefono del comercio
        */
        [JsonPropertyName("MobileNumber")]
        public string? mobileNumber;

        /**
         * Correo electronico del comercio
         */
        [JsonPropertyName("UserEmail")]
        public string? userEmail;
    }
}
