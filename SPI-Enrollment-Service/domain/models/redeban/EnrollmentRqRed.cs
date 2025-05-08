using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace domain.models.redeban
{
    /// <summary>
    /// Modelo para el request enviado a la API de Enrollment de Redeban
    /// </summary>
    public class EnrollmentRqRed
    {
        /**
         * Fecha y hora en formato ISO 8601, en la cual el usuario realiza la operación.
         */
        [Required]
        [JsonPropertyName("RequestDateTime")]
        public string? requestDateTime {get; set;}

        /**
         * Instancia de la clase Customer
         */
        [Required]
        [JsonPropertyName("Customer")]
        public Customer? customer {get; set;}

        /**
         * Instancia de la clase Product
         */
        [Required]
        [JsonPropertyName("Product")]
        public Product? product {get; set;}

        /**
         * Indicador de aceptación de términos y condiciones
         * de parte del cliente para ser registrado en el directorio
         */
        [Required]
        [JsonPropertyName("TermsAndConditions")]
        public bool termsAndConditions {get; set;}

    }
}
