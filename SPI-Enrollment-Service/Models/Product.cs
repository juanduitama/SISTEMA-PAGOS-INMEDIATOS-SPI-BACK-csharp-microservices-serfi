using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Enrollment_Service.model
{
    public class Product
    {
        /// <summary>
        /// Información de la cuenta asociada al producto.
        /// </summary>
        [JsonPropertyName("Account")]
        public Account Account { get; set; }
    }
}
