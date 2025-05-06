using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SPI_Update_Service.model.enterprise
{
    public class CommerceEnterprise
    {
        [JsonPropertyName("NameCommerce")]
        public string? nameCommerce {get; set;}

        [JsonPropertyName("Alias")]
        public string? alias {get; set;}

        [JsonPropertyName("MerchantID")]
        public string? merchantID {get; set;}

        [JsonPropertyName("PostalAddress")]
        public PostalAddress? postalAddress {get; set;}

        [JsonPropertyName("ContactInformation")]
        public ContactInfo? contactInformation {get; set;}

        [JsonPropertyName("Products")]
        public Products? products {get; set;}

        [JsonPropertyName("Status")]
        public bool status {get; set;}

        [JsonPropertyName("Category")]
        public string? category {get; set;}

        [JsonPropertyName("TribCode")]
        public string? tribCode {get; set;}

        [JsonPropertyName("EcActivity")]
        public string? ecActivity {get; set;}

        [JsonPropertyName("Mdr")]
        public string? mdr {get; set;}

        [JsonPropertyName("FaceSale")]
        public bool faceSale {get; set;}

        [JsonPropertyName("NotFaceSale")]
        public bool notFaceSale {get; set;}
    }
}
