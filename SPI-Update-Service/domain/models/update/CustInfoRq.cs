using domain.models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SPI_Update_Service.domain.models.update
{
    public class CustInfoRq
    {
        
        [JsonPropertyName("custType")]
        public string custType { get; set; }

        [JsonPropertyName("custIdent")]
        public CustIdent custIdent { get; set; }
    }
}
