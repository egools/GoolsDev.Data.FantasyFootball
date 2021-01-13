using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class StandingStreak
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
