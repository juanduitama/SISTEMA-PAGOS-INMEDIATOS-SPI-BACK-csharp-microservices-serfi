using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SPI_Enrollment_Service.model.enrollment
{
    /// <summary>
    /// 
    /// </summary>
    public class EnrollmentRq
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
