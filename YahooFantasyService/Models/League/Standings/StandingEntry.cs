using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class StandingEntry
    {
        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("playoff_seed")]
        public string PlayoffSeed { get; set; }

        [JsonPropertyName("outcome_totals")]
        public StandingOutcomeTotals OutcomeTotals { get; set; }

        [JsonPropertyName("divisional_outcome_totals")]
        public StandingOutcomeTotals DivisionalOutcomeTotals { get; set; }

        [JsonPropertyName("streak")]
        public StandingStreak Streak { get; set; }

        [JsonPropertyName("points_for")]
        public string PointsFor { get; set; }

        [JsonPropertyName("points_against")]
        public double PointsAgainst { get; set; }
    }
}
