namespace SPI_Update_Service.model
{
    public class HeadersRq
    {
        /// <summary>
        /// Fecha y hora de la solicitud
        /// </summary>
        public string? Date { get; set; }

        /// <summary>
        /// Fecha y hora de la solicitud
        /// </summary>
        public string? Accept { get; set; }

        /// <summary>
        /// Tipo de contenido
        /// </summary>
        public string? ContentType { get; set; }

        /// <summary>
        /// Dirección IP de origen
        /// </summary>
        public string? XForwardedFor { get; set; }

        /// <summary>
        /// Identificador del remitente
        /// </summary>
        public string? RBMFrom { get; set; }

        /// <summary>
        /// ID único de solicitud
        /// </summary>
        public string? XRequestId { get; set; }


        /// <summary>
        /// Origen de la solicitud
        /// </summary>
        public string? Origin { get; set; }

        /// <summary>
        /// Canal de la solicitud
        /// </summary>
        public string? Channel { get; set; }

        /// <summary>
        /// ID de solicitud
        /// </summary>
        public string? RqId { get; set; }

        /// <summary>
        /// Fecha del usuario
        /// </summary>
        public string? RBMUserDate { get; set; }
    }
}
