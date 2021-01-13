using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class DraftPick
    {
        [JsonPropertyName("pick")]
        public int Pick { get; set; }

        [JsonPropertyName("round")]
        public int Round { get; set; }

        [JsonPropertyName("cost")]
        public double Cost { get; set; }

        [JsonPropertyName("team_key")]
        public string TeamKey { get; set; }

        [JsonPropertyName("player_key")]
        public string PlayerKey { get; set; }

    }
}
