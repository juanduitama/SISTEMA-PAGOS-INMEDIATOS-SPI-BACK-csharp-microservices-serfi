using SPI_lambda_consultaconstants;
using System;
using System.Collections.Generic;

namespace SPI_Inquiry_Service.Utils
{
    public class UriUtil
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUri;

        public UriUtil(IConfiguration configuration = null)
        {
            _configuration = configuration;

            // Si hay configuración disponible, usar la URL base de las configuraciones
            if (_configuration != null)
            {
                _baseUri = _configuration["ApiSettings:BaseUrl"] ?? ConstantsEnum.BASE_URI;
            }
            else
            {
                // De lo contrario, usar la URL base definida en las constantes
                _baseUri = ConstantsEnum.BASE_URI;
            }
        }

        /// <summary>
        /// Construye una URI para consultas basada en el tipo de operación y parámetros de ruta
        /// </summary>
        /// <param name="methodDescription">Tipo de operación según las constantes definidas</param>
        /// <param name="routeValues">Diccionario con los valores de ruta</param>
        /// <returns>URI completa para la operación</returns>
        public string BuildUri(string methodDescription, RouteValueDictionary routeValues = null)
        {
            switch (methodDescription)
            {
                case ConstantsEnum.KEY_INQUIRY:
                    return _baseUri + "key/" + GetRouteValue(routeValues, "keyValue");

                case ConstantsEnum.ID_INQUIRY:
                    return _baseUri + "DocumentType/" + GetRouteValue(routeValues, "DocumentType") +
                           "/identification/" + GetRouteValue(routeValues, "ID");

                case ConstantsEnum.MERCHANT_INQUIRY:
                    return _baseUri + "commerce/" + GetRouteValue(routeValues, "MerchantID");

                case ConstantsEnum.ENROLLMENT:
                    return _baseUri + "key";

                case ConstantsEnum.KEY_UPDATE:
                    return _baseUri + "key/" + GetRouteValue(routeValues, "ID");

                case ConstantsEnum.ACCOUNT_UPDATE:
                    return _baseUri + "keytype/" + GetRouteValue(routeValues, "keyType") +
                           "/key/" + GetRouteValue(routeValues, "keyValue");

                case ConstantsEnum.DELETE:
                    return _baseUri + "keytype/" + GetRouteValue(routeValues, "keyType") +
                           "/key/" + GetRouteValue(routeValues, "keyValue");

                default:
                    return _baseUri;
            }
        }

     
        /// <summary>
        /// Obtiene un valor de la ruta de forma segura
        /// </summary>
        /// <param name="routeValues">Diccionario de valores de ruta</param>
        /// <param name="key">Clave a buscar</param>
        /// <returns>Valor encontrado o cadena vacía</returns>
        private string GetRouteValue(RouteValueDictionary routeValues, string key)
        {
            if (routeValues == null || !routeValues.TryGetValue(key, out var value))
            {
                return string.Empty;
            }

            return value?.ToString() ?? string.Empty;
        }
    }
}