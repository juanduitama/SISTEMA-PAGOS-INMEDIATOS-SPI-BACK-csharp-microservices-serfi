
using System.Text.Json.Serialization;

namespace domain.models.oAuth
{
    public class RqOAuth
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("scopes")]
        public string scopes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("grant_type")]
        public string grantType { get; set; }


    }
}
