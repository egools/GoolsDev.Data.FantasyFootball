using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class YahooLeagueStandings : YahooLeagueBase
    {
        public List<TeamStanding> Standings { get; set; }
    }

    public class TeamStanding
    {
        [JsonPropertyName("team_key")]
        public string TeamKey { get; set; }

        [JsonPropertyName("team_id")]
        public string TeamId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("division_id")]
        public string DivisionId { get; set; }

        [JsonPropertyName("waiver_priority")]
        public int WaiverPriority { get; set; }

        [JsonPropertyName("faab_balance")]
        public string FaabBalance { get; set; }

        [JsonPropertyName("number_of_moves")]
        public string NumberOfMoves { get; set; }

        [JsonPropertyName("number_of_trades")]
        public int NumberOfTrades { get; set; }

        [JsonPropertyName("roster_adds")]
        public RosterAdds RosterAdds { get; set; }

        [JsonPropertyName("clinched_playoffs")]
        public int ClinchedPlayoffs { get; set; }

        [JsonPropertyName("league_scoring_type")]
        public string LeagueScoringType { get; set; }

        [JsonPropertyName("has_draft_grade")]
        public int HasDraftGrade { get; set; }

        [JsonPropertyName("auction_budget_total")]
        public string AuctionBudgetTotal { get; set; }

        [JsonPropertyName("auction_budget_spent")]
        public int AuctionBudgetSpent { get; set; }

        [JsonPropertyName("managers")]
        public List<YahooManager> Managers { get; set; }

        [JsonPropertyName("team_points")]
        public TeamPoints TeamPoints { get; set; }

        [JsonPropertyName("team_standings")]
        public StandingEntry StandingEntry { get; set; }
    }

    public class RosterAdds
    {
        [JsonPropertyName("coverage_type")]
        public string CoverageType { get; set; }

        [JsonPropertyName("coverage_value")]
        public string CoverageValue { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class TeamPoints
    {
        [JsonPropertyName("coverage_type")]
        public string CoverageType { get; set; }

        [JsonPropertyName("season")]
        public string Season { get; set; }

        [JsonPropertyName("total")]
        public string Total { get; set; }
    }

    public class OutcomeTotals
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

    public class Streak
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class StandingEntry
    {
        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("playoff_seed")]
        public string PlayoffSeed { get; set; }

        [JsonPropertyName("outcome_totals")]
        public OutcomeTotals OutcomeTotals { get; set; }

        [JsonPropertyName("divisional_outcome_totals")]
        public OutcomeTotals DivisionalOutcomeTotals { get; set; }

        [JsonPropertyName("streak")]
        public Streak Streak { get; set; }

        [JsonPropertyName("points_for")]
        public string PointsFor { get; set; }

        [JsonPropertyName("points_against")]
        public double PointsAgainst { get; set; }
    }
}
