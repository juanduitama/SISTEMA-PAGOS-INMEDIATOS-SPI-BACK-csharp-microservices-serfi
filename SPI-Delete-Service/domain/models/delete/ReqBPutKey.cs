using domain.models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace SPI_Delete_Service.domain.models.delete
{
    public class ReqBPutKey
    {
        [ValidateNever]
        [JsonPropertyName("key")]
        public Key key { get; set; }

        [ValidateNever]
        [JsonPropertyName("vaultInsc")]
        public VaultInsc vaultInsc { get; set; }


        [JsonPropertyName("effDtKey")]
        public EffDtKey effDtKey { get; set; }
    }
}
