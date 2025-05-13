
using System.Text.Json.Serialization;

namespace domain.models.oAuth
{
    public class RsOAuth
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("token_type")]
        public string? tokenType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("access_token")]
        public string? accessToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("scope")]
        public string? scope { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int? expiresIn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("consented_on")]
        public int? consentedOn { get; set; }


    }
}
