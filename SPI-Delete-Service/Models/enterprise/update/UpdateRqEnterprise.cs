using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SPI_Delete_Service.model.enterprise.update
{
    public class UpdateRqEnterprise
    {
        /**
         * Fecha y hora en formato ISO 8601, en la cual
         * el usuario inicia la operación
         */
        [JsonPropertyName("RequestDateTime")]
        public string? requestDateTime{ get; set;}

        /**
         * Nombre de la persona, empresa, comercio o negocio.
         * Se refiere al propietario de la cuenta o dispositivo
         * que proporciona un medio de identificación
         */
        [JsonPropertyName("NameEnterprise")]
        public string? nameEnterprise{ get; set;}

        /**
         * Persona o empresa que representa a la empresa o negocio
         */
        [JsonPropertyName("LegalRepresentative")]
        public LegalRepresentative? legalRepresentative{ get; set;}

        /**
         * Tipo de documento con que se identifica o se asocia
         * la identidad del participante
         */
        [JsonPropertyName("DocumentType")]
        public string? documentType{ get; set;}

        /**
         * Identificación única, asignada a la persona,
         * empresa, comercio
         */
        [JsonPropertyName("DocumentNumber")]
        public string? documentNumber{ get; set;}

        /**
         * Instancia de la clase EnterpriseContact
         */
        [JsonPropertyName("EnterpriseContact")]
        public EnterpriseContact? enterpriseContact{ get; set;}

        /**
         * Lista con información del comercio
         */
        [JsonPropertyName("Commerce")]
        public List<CommerceEnterprise>? commerce{ get; set;}

        /**
         * Referencia de estado
         */
        [JsonPropertyName("Status")]
        public bool status{ get; set;}

        /**
         * Tipo de cliente
         */
        [JsonPropertyName("EnterpriseType")]
        public string? enterpriseType{ get; set;}

    }
}
