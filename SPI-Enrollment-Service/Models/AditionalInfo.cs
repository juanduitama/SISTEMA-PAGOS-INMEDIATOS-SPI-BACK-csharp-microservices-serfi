using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Enrollment_Service.model
{
    public class AditionalInfo
    {
    
        [JsonPropertyName("codigo")]
        public string? codigo { get; set; }

        [JsonPropertyName("detalle")]
        public string? detalle { get; set; }
    }
}
