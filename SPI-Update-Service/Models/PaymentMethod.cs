using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Update_Service.model
{
    public class PaymentMethod
    {
        /**
        * Tipo del medio de pago seleccionado por el cliente para identificarse en el Sistema de pago de bajo valor inmediato.
        * | CAHO: Cuentas de ahorro
        * | CCTE: Cuentas corrientes
        * | DBMO: Depósitos de bajo monto
        * | DORD: Depósitos ordinarios
        * | DBMI: Depósitos de bajo monto inclusivos
        */
        [JsonPropertyName("Type")]
        public string? type { get; set; }

        /**
         * Identificación del medio de pago asignada al participante
         */
        [JsonPropertyName("Number")]
        public string? number { get; set; }
    }
}
