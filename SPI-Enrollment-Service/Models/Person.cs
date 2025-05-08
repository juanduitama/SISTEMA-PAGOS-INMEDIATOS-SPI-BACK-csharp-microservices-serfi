using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Enrollment_Service.model
{
    public class Person
    {

         /**
         * Primer nombre del cliente
         */
        [JsonPropertyName("FirstName")]
        public string? firstName {get; set;}

            /**
             * Segundo nombre del cliente
             */
        [JsonPropertyName("MiddleName")]
        public string? middleName {get; set;}

            /**
             * Primer apellido del cliente
             */
        [JsonPropertyName("FirstSurName")]
        public string? firstSurName {get; set;}

            /**
             * Segundo apellido del cliente
             */
        [JsonPropertyName("MiddleSurName")]
        public string? middleSurName {get; set;}

            /**
             * Tipo de documento (CC,CE, NUIP, PPT, NIT,
             * PEP, PAS, TDI, OTR)
             */
        [JsonPropertyName("DocumentType")]
        public string? documentType {get; set;}

            /**
             * Numero de documento
             */
        [JsonPropertyName("DocumentNumber")]
        public string? documentNumber {get; set;}

            /**
             * Fecha de expedición del documento en formato ISO 8601
             */
        [JsonPropertyName("DocumentIssuanceDate")]
        public string? documentIssuanceDate {get; set;}

            /**
             * Instancia de la clase PersonContact
             */
        [JsonPropertyName("PersonContact")]
        public CustContact? personContact {get; set;}
    }
}
