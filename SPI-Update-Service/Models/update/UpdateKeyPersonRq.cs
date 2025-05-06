using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Update_Service.model.update
{
    public class UpdateKeyPersonRq
    {
        /**
         * Fecha del cuerpo de la solicitud
         */
        [JsonPropertyName("RequestDateTime")]
        public string? requestDateTime { get; set; }

        /**
         * Tipo de la llave vieja
         */
        [JsonPropertyName("PartySystemIdentifier")]
        public string? keyType { get; set; }

        /**
         * Valor de la llave vieja
         */
        [JsonPropertyName("PartyIdentifier")]
        public string? keyValue { get; set; }

        /**
         * Tipo de la llave nueva
         */
        [JsonPropertyName("NewPartySystemIdentifier")]
        public string? newKeyType { get; set; }

        /**
         * Valor de la llave nueva
         */
        [JsonPropertyName("NewPartyIdentifier")]
        public string? newKeyValue { get; set; }
    }
}
