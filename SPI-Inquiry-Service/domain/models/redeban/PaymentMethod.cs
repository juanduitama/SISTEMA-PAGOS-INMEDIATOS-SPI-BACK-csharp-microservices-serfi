using System.Text.Json.Serialization;

namespace SPI_Inquiry_Service.domain.models.redeban
{
    public class PaymentMethod
    {
        [JsonPropertyName("Type")]
        public string? acctType { get; set; }
        [JsonPropertyName("Number")]
        public string? number { get; set; }
    }
}
