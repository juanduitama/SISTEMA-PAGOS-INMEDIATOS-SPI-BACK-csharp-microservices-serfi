using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Delete_Service.model.enterprise.enrollment
{
    public class EnrollmentEnterpriseRq
    {
         /**
         * Fecha y hora en la cual el usuario inicia la operacion
         */
        [JsonPropertyName("RequestDateTime")]
        public string? requestDateTime {get; set;}

        /**
         * Nombre de la persona, empresa, comercio o negocio
         */
        [JsonPropertyName("NameEnterprise")]
        public string? nameEnterprise {get; set;}

        /**
         * Objeto de informacion del representante legal
         */
        [JsonPropertyName("LegalRepresentative")]
        public LegalRepresentative? legalRepresentative {get; set;}

        /**
         * Tipo de documento con que se identifica o se asocia la identidad del participante.
         */
        [JsonPropertyName("DocumentType")]
        public string? documentType {get; set;}

        /**
         * Identificación única, asignada a la persona, empresa, comercio.
         */
        [JsonPropertyName("DocumentNumber")]
        public string? documentNumber {get; set;}

        /**
         * Objeto de la informacion de contacto de la empresa
         */
        [JsonPropertyName("EnterpriseContact")]
        public EnterpriseContact? enterpriseContact {get; set;}

        /**
         * Lista de informacion de la empresa.
         */
        [JsonPropertyName("Commerce")]
        public CommerceList? commerceList {get; set;}

        /**
         * Estado del comercion
         */
        [JsonPropertyName("Status")]
        public bool status {get; set;}

        /**
         * Tipo de cliente. PN para Persona natural y PJ para Persona jurídica
         */
        [JsonPropertyName("EnterpriseType")]
        public string? enterpriseType {get; set;}
    }
}
