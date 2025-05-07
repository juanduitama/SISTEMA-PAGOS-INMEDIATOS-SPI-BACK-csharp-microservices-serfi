using SPI_Enrollment_Service.model;
using Models;
using Models.enrollment;
using SPI_Enrollment_Service.Models.redeban.response;
using SPI_Enrollment_Service.Models.enrollment;
using SPI_Enrollment_Service.Models.redeban;

namespace SPI_Enrollment_Service.service.create
{
    public interface IRedEnrollmentService
    {
        /// <summary>
        /// Realiza una operación de creación (POST) a un endpoint de la API Red.
        /// </summary>
        /// <param name="url">URL completa del endpoint al que se enviará la petición.</param>
        /// <param name="headers">Objeto que contiene las cabeceras HTTP requeridas para la petición.</param>
        /// <param name="requestBody">Objeto que contiene los datos a enviar en el cuerpo de la solicitud.</param>
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
        Task<MessageInformation> Create(string url, HeadersRq headers, EnrollmentRqRed requestBody);


    }
}
