using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace SPI_Update_Service.Utils.util
{
    /// <summary>
    /// clase builderhttp
    /// </summary>
    public class BuilderHttpUtil
    {
        public BuilderHttpUtil()
        {
        }

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