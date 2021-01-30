using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class YahooMatchupTeam : YahooTeamBase
    {
        [JsonProperty(PropertyName = "win_probability")]
        public double WinProbability { get; set; }

        [JsonProperty(PropertyName = "team_points")]
        public MatchupTeamPoints TeamPoints { get; set; }

        [JsonProperty(PropertyName = "team_projected_points")]
        public MatchupTeamPoints TeamProjectedPoints { get; set; }

        public static YahooMatchupTeam FromJTokens(List<JToken> team)
        {
            var matchupTeam = CondenseTeamJTokens(team);
            return matchupTeam.ToObject<YahooMatchupTeam>();
        }
    }
}