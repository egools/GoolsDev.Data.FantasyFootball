using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        [JsonProperty(PropertyName = "is_tied")]
        public int IsTied { get; set; }

        [JsonProperty(PropertyName = "winner_team_key")]
        public string WinnerTeamKey { get; set; }

        [JsonProperty(PropertyName = "matchup_grades")]
        public List<MatchupGrade> MatchupGrades { get; set; }

        public List<YahooMatchupTeam> MatchupTeams { get; set; }

        [JsonExtensionData]
        private IDictionary<string, JToken> _matchupTeamData;

        [OnDeserialized]
        private void OnDeserialized(StreamingContext streamingContext)
        {
            if (_matchupTeamData.TryGetValue("0", out JToken matchup))
            {
                MatchupTeams = new List<YahooMatchupTeam>();
                foreach(var matchupTeam in matchup.SelectTokens("teams..team"))
                {
                    var tempMatchupTeam = matchupTeam[1];
                    var baseTeamProps = matchupTeam[0].SelectTokens("[*]").Select(j => j.FirstOrDefault());
                    foreach(var baseTeamProp in baseTeamProps)
                    {
                        if(baseTeamProp is JProperty prop)
                            tempMatchupTeam[prop.Name] = prop.Value;
                    }
                    MatchupTeams.Add(tempMatchupTeam.ToObject<YahooMatchupTeam>());
                }

            }
        }
    }

    public class MatchupGrade
    {
        [JsonConstructor]
        public MatchupGrade(JToken matchup_grade)
        {
            TeamKey = matchup_grade["team_key"].ToString();
            Grade = matchup_grade["grade"].ToString();
        }

        public string TeamKey { get; set; }

        public string Grade { get; set; }
    }

}