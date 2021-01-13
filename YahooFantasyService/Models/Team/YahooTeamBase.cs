using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class YahooTeamBase
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
        public StandingRosterAdds RosterAdds { get; set; }

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
    }
}
