using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Enrollment_Service.model
{
    public class Identification
    {
        /**
         * Tipo de documento con que se identifica o se asocia la identidad del participante,
         * no se pueden incluir guiones, espacios o puntos.
         * | CC: Cédula de ciudadanía | CE: Cédula de Extranjería
         * | PPT: Permiso de Protección Temporal
         * | NIT: Número de Identificación Tributaria, sin digito de verificación
         * | PEP: Permiso Especial de Permanencia
         * | PAS: Número de Pasaporte
         * | OTR: Otro |
         */
        [JsonPropertyName("Type")]
        public string? type { get; set; }

        /**
         * Número Identificación única, asignada al participante
         */
        [JsonPropertyName("Number")]
        public string? number { get; set; }
    }
}
