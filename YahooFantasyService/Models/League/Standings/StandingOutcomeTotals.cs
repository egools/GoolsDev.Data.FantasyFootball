using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class StandingOutcomeTotals
    {
        [JsonPropertyName("wins")]
        public string Wins { get; set; }

        [JsonPropertyName("losses")]
        public string Losses { get; set; }

        [JsonPropertyName("ties")]
        public int Ties { get; set; }

        [JsonPropertyName("percentage")]
        public string Percentage { get; set; }
    }
}
