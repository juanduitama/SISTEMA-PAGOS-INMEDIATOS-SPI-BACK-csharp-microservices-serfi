using SPI_Enrollment_Service.model.enterprise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Enrollment_Service.model
{
    public class Customer
    {

        [JsonPropertyName("PartySystemIdentifier")]
        public string? partySystemIdentifier { get; set; }

        [JsonPropertyName("PartyIdentifier")]
        public string? partyIdentifier { get; set; }

        [JsonPropertyName("Type")]
        public string? type { get; set; }

        [JsonPropertyName("Person")]
        public Person? person { get; set; }

        [JsonPropertyName("Commerce")]
        public Commerce? commerce { get; set; }




    }
}
