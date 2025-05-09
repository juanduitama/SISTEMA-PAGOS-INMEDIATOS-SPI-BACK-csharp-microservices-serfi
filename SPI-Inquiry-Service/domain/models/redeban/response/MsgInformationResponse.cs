using SPI_Inquiry_Service.domain.models;
using SPI_Inquiry_Service.domain.models.redeban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace domain.models.redeban.response
{
    public class MsgInformationResponse
    {

        /**
         * Objeto del mensaje de respuesta
         */
        [JsonPropertyName("Key")]
        public UpdateKey? key { get; set; }

        [JsonPropertyName("Identification")]
        public Identification? identification { get; set; }

        [JsonPropertyName("Customer")]
        public Customer? customer { get; set; }

        [JsonPropertyName("IssuingEntity")]
        public IssuingEntity? issuingEntity { get; set; }

        [JsonPropertyName("PaymentMethod")]
        public PaymentMethod? paymentMethod { get; set; }
        /**
         * Representa que hay una lista de tipo Envelope en el cuerpo del mensaje
         */
        [JsonPropertyName("AdditionalData")]
        public AdditionalData? aditionalData { get; set; }
    }
}
