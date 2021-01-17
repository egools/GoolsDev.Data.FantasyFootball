using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class SettingsRosterPosition
    {
        [JsonProperty(PropertyName = "position")]
        public string Position { get; set; }

        [JsonProperty(PropertyName = "position_type")]
        public string PositionType { get; set; }

        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
    }
}
