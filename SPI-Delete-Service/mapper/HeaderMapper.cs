
using SPI_Delete_Service.constants;
using SPI_Delete_Service.model;
using SPI_Delete_Serviceconstants;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;

namespace SPI_Delete_Service.util
{
    /// <summary>
    /// Utilidad para manejar encabezados HTTP
    /// </summary>
    public static class HeaderMapper
    {

        private static readonly Random random = new Random();

        /// <summary>
        /// Agrega los encabezados necesarios para la consulta a la solicitud HTTP.
        /// Configura el cliente HTTP con los encabezados requeridos para comunicarse con la API Red.
        /// </summary>
        /// <param name="request">Cliente HTTP al que se agregarán los encabezados.</param>
        /// <param name="headers">Objeto que contiene los valores de los encabezados a agregar.</param>
        /// <remarks>
        /// Incluye automáticamente encabezados generados como X-Request-ID (GUID) y 
        /// RQ-ID (número aleatorio de 12 dígitos).
        /// </remarks>
        public static void AddInquiryHeaders(HttpClient request, HeadersRq headers)
        {
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.DATE, headers.Date);
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.X_FORWARDED_FOR, headers.XForwardedFor);
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.RBM_FROM, headers.RBMFrom);
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.X_REQUEST_ID, Guid.NewGuid().ToString("D"));
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.ORIGIN, ConstantsEnum.ORIGIN);
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.CHANNEL, headers.Channel);
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.RQ_ID, random.NextInt64(100000000000, 999999999999).ToString());
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.RBM_USER_DATE, headers.RBMUserDate);
            Console.WriteLine("Estos son los headers");
            Console.WriteLine(request.DefaultRequestHeaders.ToString());
        }

        public static HeadersRq MapHeadersFromRequest(HttpRequest request)
        {
            var headersRq = new HeadersRq();

            if (request.Headers.Count == 0)
            {
                return headersRq;
            }

            var properties = typeof(HeadersRq).GetProperties();

            foreach (var header in request.Headers)
            {
                if (MapperDictionaryHeaders().TryGetValue(header.Key, out string propertyName))
                {
                    var property = properties.FirstOrDefault(p => p.Name == propertyName);
                    if (property != null)
                    {
                        property.SetValue(headersRq, header.Value.ToString());
                    }
                }
            }

            return headersRq;
        }

        public static void AddCreateHeaders(HttpClient request, HeadersRq headers)
        {
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.CONTENT_TYPE, headers.ContentType);
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.DATE, headers.Date);
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.RBM_FROM, headers.RBMFrom);
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.ACCEPT, headers.Accept);
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.X_FORWARDED_FOR, headers.XForwardedFor);
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.X_REQUEST_ID, Guid.NewGuid().ToString("D"));
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.ORIGIN, ConstantsEnum.ORIGIN);
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.CHANNEL, headers.Channel);
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.RQ_ID, random.NextInt64(100000000000, 999999999999).ToString());
            request.DefaultRequestHeaders.TryAddWithoutValidation(HeadersEnum.RBM_USER_DATE, headers.RBMUserDate);
            Console.WriteLine("Estos son los headers");

            Console.WriteLine(request.DefaultRequestHeaders.ToString());
        }



        /// <summary>
        /// Mapea los encabezados recibidos del API Gateway al modelo HeadersRq.
        /// Convierte el diccionario de strings del API Gateway en una estructura tipada.
        /// </summary>
        /// <param name="headers">Diccionario de encabezados recibidos del API Gateway.</param>
        /// <returns>
        /// Objeto HeadersRq con los valores mapeados desde el diccionario de entrada.
        /// Si los encabezados son nulos o vacíos, devuelve un objeto HeadersRq con valores predeterminados.
        /// </returns>
        /// <remarks>
        /// Utiliza reflexión para asignar dinámicamente los valores a las propiedades correspondientes
        /// según el mapeo definido en MapperDictionaryHeaders().
        /// </remarks>
        public static HeadersRq MapHeadersFromApiGateway(IDictionary<string, string> headers)
        {

            Console.WriteLine("[DEBUG] Iniciando mapeo de headers");

            var headersRq = new HeadersRq();

            if (headers == null || headers.Count == 0)
            {
                Console.WriteLine("[WARN] Headers nulos o vacíos recibidos");
                return headersRq;
            }

            // Usar reflexión para asignar los valores
            var properties = typeof(HeadersRq).GetProperties();

            foreach (var header in headers)
            {
                if (MapperDictionaryHeaders().TryGetValue(header.Key, out string propertyName))
                {
                    var property = properties.FirstOrDefault(p => p.Name == propertyName);
                    if (property != null)
                    {
                        property.SetValue(headersRq, header.Value);
                        Console.WriteLine($"[DEBUG] Mapeado {header.Key} a {propertyName}: {header.Value}");
                    }

                }
                Console.WriteLine(header);
            }
            

            return headersRq;
        }


        /// <summary>
        /// Crea un diccionario que mapea los nombres de encabezados HTTP a los nombres de propiedades del modelo HeadersRq.
        /// </summary>
        /// <returns>
        /// Diccionario con pares clave-valor donde la clave es el nombre del encabezado HTTP
        /// y el valor es el nombre de la propiedad correspondiente en el modelo HeadersRq.
        /// </returns>
        /// <remarks>
        /// El diccionario utiliza comparación de strings sin distinción entre mayúsculas y minúsculas
        /// para permitir búsquedas independientes del caso. Esto es importante ya que los nombres
        /// de encabezados HTTP no son sensibles a mayúsculas/minúsculas según el estándar.
        /// </remarks>
        public static IDictionary<string, string> MapperDictionaryHeaders()
        {
        return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
            { HeadersEnum.CONTENT_TYPE,nameof(HeadersRq.ContentType)},
            { HeadersEnum.DATE, nameof(HeadersRq.Date) },
            { HeadersEnum.X_FORWARDED_FOR, nameof(HeadersRq.XForwardedFor) },
            { HeadersEnum.RBM_FROM, nameof(HeadersRq.RBMFrom) },
            { HeadersEnum.X_REQUEST_ID, nameof(HeadersRq.XRequestId) },
            { HeadersEnum.ORIGIN, nameof(HeadersRq.Origin) },
            { HeadersEnum.CHANNEL, nameof(HeadersRq.Channel) },
            { HeadersEnum.RQ_ID, nameof(HeadersRq.RqId) },
            { HeadersEnum.RBM_USER_DATE, nameof(HeadersRq.RBMUserDate) },
            { HeadersEnum.ACCEPT, nameof(HeadersRq.Accept) },
            };
        }

    }
}
