using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPI_Enrollment_Service.constants
{
    /// <summary>
    /// HeadersEnum define los valores para los encabezados
    /// </summary>
    public static class RedHeadersEnum
    {
        /// <summary>
        /// Indica el tamaño anticipado del cuerpo de carga útil.
        /// </summary>
        public const string CONTENT_LENGTH = "Content-Length";

        /// <summary>
        /// El token de autorizacion para el consumo del servicio.
        /// </summary>
        public const string AUTHORIZATION = "Authorization";

        /// <summary>
        /// Indica el tipo de medio original del recurso.
        /// </summary>
        public const string CONTENT_TYPE = "Content-Type";

        /// <summary>
        /// Indica la fecha y hora en que se invocó el servicio por la entidad.
        /// </summary>
        public const string DATE = "Date";

        /// <summary>
        /// El origen de la dirección IP de un cliente.
        /// </summary>
        public const string X_FORWARDED_FOR = "X-Forwarded-For";

        /// <summary>
        /// Campo estándar que no es HTTP utilizado por la API para aplicar
        /// el cifrado de un extremo a otro de la solicitud.
        /// </summary>
        public const string RBMDIGEST = "RBMDigest";

        /// <summary>
        /// Campo estándar que no es HTTP utilizado por la API para aplicar
        /// una firma de solicitud de un extremo a otro.
        /// </summary>
        public const string RBMSIGNATURE = "RBMSignature";

        /// <summary>
        /// campo estándar no HTTP utilizado por la API para validar la firma,
        /// debe contener el URI del servicio.
        /// </summary>
        public const string RBMURI = "RBMURI";

        /// <summary>
        /// Campo estándar no HTTP utilizado por la API para identificar al
        /// remitente de la solicitud HTTP.
        /// </summary>
        public const string RBM_FROM = "RBM-FROM";

        /// <summary>
        /// Campo utilizado para identificar al receptor de la solicitud HTTP
        /// </summary>
        public const string RBM_TO = "RBM-TO";

        /// <summary>
        /// Se usa para indicar el tipo de contenido aceptado del
        /// recurso de la transmisión.
        /// </summary>
        public const string ACCEPT = "Accept";

        /// <summary>
        /// Encabezado para la transmisión de coordenadas geográficas en el
        /// formato ISO 6709, usando el formato '±DD.DDDD±DDD.DDDD
        /// </summary>
        public const string GEOLOCATION = "Geolocation";

        /// <summary>
        /// UUID para identificar la solicitud única con la respuesta HTTP de los clientes
        /// </summary>
        public const string X_REQUEST_ID = "X-Request-ID";

        /// <summary>
        /// UUID para transmitir una huella digital del dispositivo.
        /// </summary>
        public const string X_DEVICE_FINGERPRINT = "X-Device-Fingerprint";

        /// <summary>
        /// Indica de dónde se origina una búsqueda. No incluye ninguna información de ruta,
        /// sino solo el nombre del servidor y el puerto.
        /// </summary>
        public const string ORIGIN = "Origin";

        public const string CHANNEL = "X-Channel";

        public const string RQ_ID = "X-RqUID";

        public const string RBM_USER_DATE = "RBM-UserDate";


    }
}
