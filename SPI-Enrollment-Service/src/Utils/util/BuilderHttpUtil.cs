using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace Util.util
{
    /// <summary>
    /// clase builderhttp
    /// </summary>
    public class BuilderHttpUtil
    {
        public BuilderHttpUtil()
        {
        }
        //private readonly string _serverCertPath = "client_rdb.pem";  // certificado del servidor
        private readonly string _serverCertPath = "-----BEGIN CERTIFICATE-----\r\n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\r\n12wk9J6L+D9Iy7/5y/i5VkH0xQ==\r\n-----END CERTIFICATE-----\r\n";  // certificado del servidor
        
        private readonly string _clientCertPath = "ruta/al/certificado_cliente.pfx";    // certificado cliente (incluye clave privada)
        private readonly string _clientCertPassword = "password_del_pfx";               // si aplica

        // ✅ Crea un cliente confiando en un certificado .pem del servidor
        public HttpClient BuildClientWithServerCertificate()
        {
            Console.WriteLine("[INFO] Configurando HttpClient confiando en certificado del servidor (.pem)");

            var trustedCert = LoadTrustedServerCertificate();

            var handler = new HttpClientHandler
            {
                SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13,
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                {
                    if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
                        return true;

                    Console.WriteLine("[INFO] Validando certificado del servidor...");
                    return cert?.GetCertHashString() == trustedCert.GetCertHashString();
                }
            };

            return new HttpClient(handler);
        }

        // ✅ Crea un cliente que se autentica usando un certificado cliente (.pfx)
        public HttpClient BuildClientWithClientCertificate()
        {
            Console.WriteLine("[INFO] Configurando HttpClient con certificado de cliente (.pfx)");

            var handler = new HttpClientHandler
            {
                SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13
            };

            var clientCertificate = new X509Certificate2(_clientCertPath, _clientCertPassword);
            handler.ClientCertificates.Add(clientCertificate);

            return new HttpClient(handler);
        }

        // 🔧 Método de utilidad para cargar un certificado del servidor desde .pem
        private X509Certificate2 LoadTrustedServerCertificate()
        {
            var serverCertPath = Environment.GetEnvironmentVariable("CERTIFICATE");
            //var serverCertPath = _configuration["ertificate"];

            if (string.IsNullOrEmpty(serverCertPath))
            {
                throw new InvalidOperationException("No se encontró la configuración 'certificate'");
            }
            Console.WriteLine("[INFO] Certificado del servidor cargado correctamente desde configuración");

            var certBytes = GetBytesFromPem(serverCertPath, "CERTIFICATE");

            return new X509Certificate2(certBytes);
        }

        // 🔧 Extrae bytes desde un archivo PEM
        private static byte[] GetBytesFromPem(string pemString, string section)
        {
            var header = $"-----BEGIN {section}-----";
            var footer = $"-----END {section}-----";

            var start = pemString.IndexOf(header, StringComparison.Ordinal);
            var end = pemString.IndexOf(footer, StringComparison.Ordinal);

            if (start < 0 || end < 0)
                throw new InvalidOperationException("Certificado PEM no contiene la sección esperada.");

            var base64 = pemString.Substring(start + header.Length, end - start - header.Length);
            return Convert.FromBase64String(base64.Trim());
        }
    }
}
