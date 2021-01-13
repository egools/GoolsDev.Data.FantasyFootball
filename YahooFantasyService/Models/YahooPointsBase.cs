using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class YahooPointsBase
    {
        [JsonPropertyName("coverage_type")]
        public string CoverageType { get; set; }

        [JsonPropertyName("total")]
        public string Total { get; set; }
    }
}