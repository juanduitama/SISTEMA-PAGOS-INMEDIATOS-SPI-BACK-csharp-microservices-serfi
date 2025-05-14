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
        [JsonPropertyName("RequestDateTime")]
        public string? requestDateTime {get; set;}

        /**
         * Instancia de la clase Customer
         */
        [JsonPropertyName("Customer")]
        public Customer? customer {get; set;}

        /**
         * Instancia de la clase Product
         */
        [JsonPropertyName("Product")]
        public Product? product {get; set;}

        /**
         * Indicador de aceptación de términos y condiciones
         * de parte del cliente para ser registrado en el directorio
         */
        [JsonPropertyName("TermsAndConditions")]
        public bool termsAndConditions {get; set;}

    }
}
