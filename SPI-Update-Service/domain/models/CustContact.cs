using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace domain.models
{
    public class CustContact
    {
        [JsonPropertyName("custMobileNumber")]
        public string? custMobileNumber { get; set; }

        [JsonPropertyName("custEmail")]
        public string custEmail { get; set; }

    }
}
