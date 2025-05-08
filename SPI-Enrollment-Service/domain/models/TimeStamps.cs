using domain.models.redeban.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace domain.models
{
    public class TimeStamps
    {

        /**
         *
         */
        [JsonPropertyName("Envelope")]
        public Envelope? envelope { get; set; }
    }
}
