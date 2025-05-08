using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SPI_Enrollment_Service.model
{
    public class MsgInformationResponseSerfi
        //: IActionResult
    {
        /// <summary>
        /// Objeto que obtiene los metadatos de la operación.
        /// </summary>
        /// 
        [Required]
        [JsonPropertyName("meta")]
        public Meta? meta { get; set; }

        /**
        * Representa que hay un codigo de estado para conocer el estado de la operación
        */
        [Required]
        [JsonPropertyName("statusCodigo")]
        public string? statusCodigo { get; set; }

        /**
        * Representa que hay una descripción de estado para conocer el estado de la operación
        */
        [Required]
        [JsonPropertyName("statusDesc")]
        public string? statusDesc { get; set; }

        /**
         * Representa que hay una lista de tipo Envelope en el cuerpo del mensaje
         */
        [Required]
        [JsonPropertyName("aditionalInfo")]
        public  List<AditionalInfo>? aditionalInfo { get; set; }

        /**
         * Representa que hay una lista de tipo Envelope en el cuerpo del mensaje
         */
        [Required]
        [JsonPropertyName("data")]
        public Data? data {  get; set; }

        //public async Task ExecuteResultAsync(ActionContext context)
        //{
        //    var objectResult = new OkObjectResult(this);
        //    await objectResult.ExecuteResultAsync(context);
        //}
    }
}
