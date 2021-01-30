using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace YahooFantasyService
{
    public class YahooTeamStanding : YahooTeamBase
    {
        [JsonProperty(PropertyName = "team_points")]
        public StandingTeamPoints TeamPoints { get; set; }

        [JsonProperty(PropertyName = "team_standings")]
        public StandingEntry StandingEntry { get; set; }

        public static YahooTeamStanding FromJTokens(List<JToken> team)
        {
            var standingsTeam = CondenseTeamJTokens(team[1], team[0]);
            standingsTeam["team_standings"] = team[2]["team_standings"];
            return standingsTeam.ToObject<YahooTeamStanding>();
        }
    }
}
