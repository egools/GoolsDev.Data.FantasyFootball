using System.Collections.Generic;
using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class YahooMatchup
    {
        [JsonProperty(PropertyName = "week")]
        public string Week { get; set; }

        [JsonProperty(PropertyName = "week_start")]
        public string WeekStart { get; set; }

        [JsonProperty(PropertyName = "week_end")]
        public string WeekEnd { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "is_playoffs")]
        public string IsPlayoffs { get; set; }

        [JsonProperty(PropertyName = "is_consolation")]
        public string IsConsolation { get; set; }

        [JsonProperty(PropertyName = "is_matchup_recap_available")]
        public int IsMatchupRecapAvailable { get; set; }

        [JsonProperty(PropertyName = "matchup_recap_url")]
        public string MatchupRecapUrl { get; set; }

        [JsonProperty(PropertyName = "matchup_recap_title")]
        public string MatchupRecapTitle { get; set; }

        [JsonProperty(PropertyName = "matchup_grades")]
        public List<MatchupGrade> MatchupGrades { get; set; }

        [JsonProperty(PropertyName = "is_tied")]
        public int IsTied { get; set; }

        [JsonProperty(PropertyName = "winner_team_key")]
        public string WinnerTeamKey { get; set; }

        public List<YahooMatchupTeam> MatchupTeams { get; set; }
    }

    public class MatchupGrade
    {
        [JsonProperty(PropertyName = "team_key")]
        public string TeamKey { get; set; }

        [JsonProperty(PropertyName = "grade")]
        public string Grade { get; set; }
    }

}