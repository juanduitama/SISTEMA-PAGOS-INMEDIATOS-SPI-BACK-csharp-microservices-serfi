using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace domain.models
{
    public class EffDtKey
    {
        [JsonPropertyName("effDtModify")]
        public DateTime effDtModify { get; set; }
    }
}
