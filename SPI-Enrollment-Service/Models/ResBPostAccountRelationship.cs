using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPI_Enrollment_Service.model.model
{
    /// <summary>
    /// Clase que encapsula la respuesta HTTP
    /// 
    /// Desarrollo SERFINANZAS - SPBVI
    /// 
    /// Requerimiento: SPBVI - Sistema de pagos de bajo valor inmediatos
    /// </summary>
    public class ResBPostAccountRelationship
    {

        /// <summary>
        /// Cuerpo de la respuesta
        /// </summary>
        [Required]
        public MsgInformationResponseSerfi msgInformationResponse { get; set;}
    }
}
