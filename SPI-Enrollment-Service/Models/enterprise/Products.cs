using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Enrollment_Service.model.enterprise
{
    public class Products
    {
        /**
         * Lista de cuentas
         */
        [JsonPropertyName("Account")]
        public List<Account>? accounts { get; set; }
    }
}
