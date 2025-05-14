using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace domain.models.redeban
{
    public class Commerce
    {

        /**
        * Tipo de documento (CC,CE, NUIP, PPT, NIT,
        * PEP, PAS, TDI, OTR)
        */
        [JsonPropertyName("DocumentType")]
        public string? documentType { get; set; }

        /**
        * Numero de documento
        */
        [JsonPropertyName("DocumentNumber")]
        public string? documentNumber { get; set; }

        /**
        * Numero de documento
        */
        [JsonPropertyName("MerchantId")]
        public string? merchantId { get; set; }
    }
}
