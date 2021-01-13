using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class YahooMatchup
    {
        [JsonPropertyName("week")]
        public string Week { get; set; }

        [JsonPropertyName("week_start")]
        public string WeekStart { get; set; }

        [JsonPropertyName("week_end")]
        public string WeekEnd { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("is_playoffs")]
        public string IsPlayoffs { get; set; }

        [JsonPropertyName("is_consolation")]
        public string IsConsolation { get; set; }

        [JsonPropertyName("is_matchup_recap_available")]
        public int IsMatchupRecapAvailable { get; set; }

        [JsonPropertyName("matchup_recap_url")]
        public string MatchupRecapUrl { get; set; }

        [JsonPropertyName("matchup_recap_title")]
        public string MatchupRecapTitle { get; set; }

        [JsonPropertyName("matchup_grades")]
        public List<MatchupGrade> MatchupGrades { get; set; }

        [JsonPropertyName("is_tied")]
        public int IsTied { get; set; }

        [JsonPropertyName("winner_team_key")]
        public string WinnerTeamKey { get; set; }

        public List<YahooMatchupTeam> MatchupTeams { get; set; }
    }

    public class MatchupGrade
    {
        [JsonPropertyName("team_key")]
        public string TeamKey { get; set; }

        [JsonPropertyName("grade")]
        public string Grade { get; set; }
    }

}