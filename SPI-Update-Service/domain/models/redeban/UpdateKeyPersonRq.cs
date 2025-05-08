using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Update_Service.domain.models.redeban
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
        public string? partySystemIdentifier { get; set; }

        /**
         * Valor de la llave vieja
         */
        [JsonPropertyName("PartyIdentifier")]
        public string? partyIdentifier { get; set; }

        /**
         * Tipo de la llave nueva
         */
        [JsonPropertyName("NewPartySystemIdentifier")]
        public string? newPartySystemIdentifier { get; set; }

        /**
         * Valor de la llave nueva
         */
        [JsonPropertyName("NewPartyIdentifier")]
        public string? newPartyIdentifier { get; set; }
    }
}
