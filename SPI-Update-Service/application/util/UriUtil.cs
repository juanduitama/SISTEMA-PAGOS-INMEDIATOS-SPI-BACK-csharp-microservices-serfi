using domain.constants;
using System;
using System.Collections.Generic;

namespace application.Util
{
    public class UriUtil
    {

        /// <summary>
        /// Construye una URI para consultas basada en el tipo de operación y parámetros de ruta
        /// </summary>
        /// <param name="methodDescription">Tipo de operación según las constantes definidas</param>
        /// <param name="routeValues">Diccionario con los valores de ruta</param>
        /// <returns>URI completa para la operación</returns>
        public string BuildUriAccount(string valueKey, string valueType)
            {

            string _baseUri = ConstantsEnum.BASE_URI_ACCOUNT;
                string newUrl = getValuePathParameters(_baseUri, ConstantsEnum.KEY_TYPE_PATH, valueType);

            newUrl = getValuePathParameters(newUrl, ConstantsEnum.KEY_VALUE_PATH, valueKey);

            Console.WriteLine("new url final: " + newUrl);

            return newUrl;
            }
        

        public string BuildUriKey(string valueId)
            {
                string _baseUri = ConstantsEnum.BASE_URI_KEY;
            Console.WriteLine("Base url: "+_baseUri);
            return getValuePathParameters(_baseUri, ConstantsEnum.ID_PATH, valueId);
            }
        

     
        /// <summary>
        /// Obtiene un valor de la ruta de forma segura
        /// </summary>
        /// <param name="routeValues">Diccionario de valores de ruta</param>
        /// <param name="key">Clave a buscar</param>
        /// <returns>Valor encontrado o cadena vacía</returns>
        private string getValuePathParameters(string uri, string pathParameter, string valueParameter)
            {
                if (uri.Contains(pathParameter))
                {
                    return uri.Replace(pathParameter, valueParameter);
                }

                return uri;
            
            }
    }
}