using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SPI_lambda_consulta.model
{
    public class Key
    {
        /**
         * Tipo de llave seleccionada por el cliente para identificarse en el Sistema de pago de bajo valor inmediato.
         * | MERCHANTID: Identificador de codigo único
         * | USERIDENTIFICATION: Documento de identidad
         * |MSISDN: Número de celular
         * | EMAIL: Correo electrónico
         * | ALIAS: Identificador alfanumérico |
         */
        [JsonPropertyName("Type")]
        public string? type { get; set; }

        /**
         * Llave utilizada para identificar el receptor,
         * debe corresponder al tipo enviado en el campo “KeyType”
         */
        [JsonPropertyName("Value")]
        public string? value { get; set; }

        /**
         * Indica la fecha y hora en que se realizó la creación de la llave
         */
        [JsonPropertyName("CreatedDate")]
        public string? createdDate { get; set; }

        /**
         * Indica la fecha y hora en que se realizó la solicitud de la transacción
         */
        [JsonPropertyName("UpdatedDate")]
        public string? updatedDate { get; set; }

        /**
         * Estado de la llave | ACTIVA: Activa | BLOQUEADA: Bloqueada
         * | ON_HOLD: Suspendida por proceso de portabilidad | CANCELADA: Cancelada
         */
        [JsonPropertyName("KeyState")]
        public string? keyState { get; set; }

        /**
         * Sistema de Pago de Bajo Valor Inmediato al que pertenece la llave
         */
        [JsonPropertyName("InstructedAgent")]
        public string? instructedAgent { get; set; }

        /**
         * Bandera que representa si la llave se registró en el Directorio Centralizado (DICE)]
         */
        [JsonPropertyName("DICE")]
        public bool dice { get; set; }
    }
}
