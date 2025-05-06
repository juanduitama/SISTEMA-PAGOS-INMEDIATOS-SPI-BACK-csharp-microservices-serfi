using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_lambda_consulta.model.enterprise
{
    public class LegalRepresentative
    {
        /**
         * Nombre del representante legal
         */
        [JsonPropertyName("Name")]
        public string? name {get; set;}

        /**
         * Tipo de documento del representante legal
         */
        [JsonPropertyName("DocumentType")]
        public string? documentType {get; set;}

        /**
         * Número de documento del representante legal
         */
        [JsonPropertyName("DocumentNumber")]
        public string? documentNumber {get; set;}

        /**
         * Correo electronico del representante legal
         */
        [JsonPropertyName("Email")]
        public string? email {get; set;}

        /**
         * Numero de celular del representante legal
         */
        [JsonPropertyName("MobileNumber")]
        public string? mobileNumber {get; set;}

        /**
         * Fecha de expedicion del documento del representante legal
         */
        [JsonPropertyName("DocumentIssuanceDate")]
        public string? docIssuanceDate {get; set;}
    }
}
