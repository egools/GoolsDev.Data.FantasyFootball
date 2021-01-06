using System;
using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    internal class YahooAuthToken
    {
        public string AccessToken { get; set; }
        public DateTime TokenExpiration { get; set; }
    }

    internal class YahooTokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
    }
}
