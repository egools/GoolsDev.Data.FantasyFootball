using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class StandingRosterAdds
    {
        [JsonPropertyName("coverage_type")]
        public string CoverageType { get; set; }

        [JsonPropertyName("coverage_value")]
        public string CoverageValue { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
