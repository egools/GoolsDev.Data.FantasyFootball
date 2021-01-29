using Newtonsoft.Json;

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
    }
}