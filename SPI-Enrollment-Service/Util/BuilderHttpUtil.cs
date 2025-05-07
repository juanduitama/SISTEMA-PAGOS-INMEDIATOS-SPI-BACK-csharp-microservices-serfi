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

            Console.WriteLine("[INFO] Configurando HttpClient con validación SSL personalizada");
            var handler = new HttpClientHandler
                {
                //ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                {
                    Console.WriteLine($"[INFO] Validación de certificado: {sslPolicyErrors}");
                    return true;
                },
                SslProtocols = System.Security.Authentication.SslProtocols.Tls12 | System.Security.Authentication.SslProtocols.Tls13,
                AllowAutoRedirect = true,
                MaxConnectionsPerServer = 10
            };

                return new HttpClient(handler);
            }
        
    }
}