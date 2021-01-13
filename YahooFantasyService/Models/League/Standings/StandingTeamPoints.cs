using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class StandingTeamPoints
    {
        [JsonPropertyName("coverage_type")]
        public string CoverageType { get; set; }

        [JsonPropertyName("season")]
        public string Season { get; set; }

        [JsonPropertyName("total")]
        public string Total { get; set; }
    }
}
