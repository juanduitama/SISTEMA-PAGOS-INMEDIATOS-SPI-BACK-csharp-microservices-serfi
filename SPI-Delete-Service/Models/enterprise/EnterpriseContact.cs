using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Delete_Service.model.enterprise
{
    public class EnterpriseContact
    {
        /**
         * Objeto de la informacion postal
         */
        [JsonPropertyName("PostalAddress")]
        public PostalAddress? postalAddress { get; set; }
    }
}
