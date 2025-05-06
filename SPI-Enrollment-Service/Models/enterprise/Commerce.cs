using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SPI_Enrollment_Service.model.enterprise
{
    public class Commerce
    {
        /**
         * Nombre de la persona, empresa, comercio o negocio
         */
        [JsonPropertyName("DocumentType")]
        public string? documentType { get;set;}

        /**
         * Identificador alfanumerico, es un identidicador creado por el participante
         */
        [JsonPropertyName("DocumentNumber")]
        public string? documentNumber { get;set;}

        /**
         * Tipo de llave seleccionada por el cliente para identificarse en el sistema
         */
        [JsonPropertyName("MerchantId")]
        public string? merchantId { get;set;}
    }
}
