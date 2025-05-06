using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Update_Service.model.enterprise
{
    public class Account
    {
        /**
        * Identificador único del producto asignado por el banco
        */
        [JsonPropertyName("ProductID")]
        public string? productID {get; set;}

        /**
         * Código de Identificación único asignada a la entidad
         */
        [JsonPropertyName("BankId")]
        public string? bankId {get; set;}

        /**
         * Tipo del medio de pago asociado al participante
         */
        [JsonPropertyName("TypeAccount")]
        public string? typeAccount {get; set;}

        /**
         * Identificación numérica única de la cuenta
         */
        [JsonPropertyName("AccountNo")]
        public string? accountNo {get; set;}

        /**
         * Estado de la llave
         */
        [JsonPropertyName("StatusKey")]
        public string? statusKey {get; set;}
    }
}
