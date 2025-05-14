
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace SPI_Update_Service.Utils.util
{

    public static class UtilCommons
    {

        private static readonly JsonSerializerOptions _jsonOptions;


        public static async Task<T?> String2Object<T>(string jsonString)
        {
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        public static async Task<string> Object2String<T>(T obj)
        {
            return JsonSerializer.Serialize(obj, _jsonOptions);
        }
    }
}
