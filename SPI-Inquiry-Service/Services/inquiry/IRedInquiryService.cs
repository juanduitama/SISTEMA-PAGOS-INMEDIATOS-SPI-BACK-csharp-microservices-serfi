using SPI_lambda_consulta.model;
using SPI_lambda_consulta.model.delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.inquiry
{
    /// <summary>
    /// Interfaz que define el contrato para servicios de consulta a la API Red.
    /// Proporciona métodos para realizar consultas HTTP a endpoints externos
    /// utilizando parámetros específicos.
    /// </summary>
    public interface IRedInquiryService
    {
        /// <summary>
        /// Realiza una consulta HTTP a un endpoint de la API Red.
        /// </summary>
        /// <param name="url">URL completa del endpoint al que se enviará la petición.</param>
        /// <param name="headers">Objeto que contiene las cabeceras HTTP requeridas para la petición.</param>
        /// <returns>Objeto HttpResponseMessage que contiene la respuesta del servidor.</returns>
        /// <exception cref="HttpRequestException">
        /// Se lanza cuando ocurre un error en la comunicación HTTP con el servidor.
        /// </exception>
        /// <exception cref="TaskCanceledException">
        /// Se lanza cuando la petición HTTP excede el tiempo de espera configurado.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Se lanza cuando hay un problema con la configuración de la petición.
        /// </exception>
        Task<HttpResponseMessage> Inquiry(string url, HeadersRq headers);
    }
}