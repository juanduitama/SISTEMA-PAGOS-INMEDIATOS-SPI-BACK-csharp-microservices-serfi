using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPI_directory_service.Util
{
    /// <summary>
    /// Clase utilitaria para la construcción de instancias HttpClient con configuraciones personalizadas.
    /// Proporciona métodos para crear clientes HTTP con configuraciones de seguridad y rendimiento específicas.
    /// </summary>
    public class BuilderHttpUtil
    {
            public HttpClient BuildClient()
            {
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                return new HttpClient(handler);
            }
        
    }
}
