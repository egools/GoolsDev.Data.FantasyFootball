using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class SettingsRosterPosition
    {
        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("position_type")]
        public string PositionType { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
