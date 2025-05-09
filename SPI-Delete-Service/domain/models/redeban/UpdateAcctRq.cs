using domain.models.redeban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Update_Service.domain.models.redeban
{
    public class UpdateAcctRq
    {
        /**
         * Fecha y hora en formato ISO 8601, en la cual el usuario realiza la operación.
         */
        [JsonPropertyName("RequestDateTime")]
        public string? requestDateTime { get; set; }

        /**
         * Objeto donde se encuentra la información del cliente
         */
        [JsonPropertyName("Customer")]
        public Customer? customer { get; set; }

        /**
         * Objeto donde está la información
         * de la cuenta asociada al cliente
         */
        [JsonPropertyName("Product")]
        public Product? product { get; set; }
    }
}
