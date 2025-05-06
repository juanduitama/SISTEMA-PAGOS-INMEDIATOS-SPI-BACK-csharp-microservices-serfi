using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPI_Delete_Service.model.model
{
    /// <summary>
    /// Clase que encapsula la respuesta HTTP
    /// 
    /// Desarrollo SERFINANZAS - SPBVI
    /// 
    /// Requerimiento: SPBVI - Sistema de pagos de bajo valor inmediatos
    /// </summary>
    public class HttpResponseWrapper
    {
        /// <summary>
        /// Cuerpo de la respuesta
        /// </summary>
        public string Body { get; }

        /// <summary>
        /// Código de estado HTTP
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase HttpResponseWrapper
        /// </summary>
        /// <param name="body">Cuerpo de la respuesta</param>
        /// <param name="statusCode">Código de estado HTTP</param>
        public HttpResponseWrapper(string body, int statusCode)
        {
            Body = body;
            StatusCode = statusCode;
        }
    }
}
