using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Update_Service.model
{
    public class IssuingEntity
    {
        /**
         * Número de Identificación Tributaria, sin digito de verificación
         */
        [JsonPropertyName("NIT")]
        public long nit { get; set; }

        /**
         * Código de Identificación único asignada a la entidad
         */
        [JsonPropertyName("FIID")]
        public string? fiId { get; set; }

        /**
         * Corresponde al Nombre de la entidad.
         */
        [JsonPropertyName("NameEntity")]
        public string? nameEntity { get; set; }
    }
}
