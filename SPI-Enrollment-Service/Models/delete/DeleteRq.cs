using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Enrollment_Service.model.delete
{
    /// <summary>
    /// Clase que representa la solicitud de eliminación de la llave
    /// </summary>
    public class DeleteRq
    {
        /// <summary>
        /// Fecha de la petición
        /// </summary>
        [JsonPropertyName("RequestDateTime")]
        public string? requestDateTime { get; set; }

        /// <summary>
        /// Estado de la llave
        /// </summary>
        [JsonPropertyName("keyStatus")]
        public string? keyStatus { get; set; }

        /// <summary>
        /// Tipo de documento
        /// </summary>
        [JsonPropertyName("DocumentType")]
        public string? documentType { get; set; }

        /// <summary>
        /// Número de documento
        /// </summary>
        [JsonPropertyName("DocumentNumber")]
        public string? documentNumber { get; set; }
    }
}
