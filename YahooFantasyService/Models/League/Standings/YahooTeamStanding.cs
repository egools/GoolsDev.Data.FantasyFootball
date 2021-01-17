using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class YahooTeamStanding : YahooTeamBase
    {
        [JsonProperty(PropertyName = "team_points")]
        public StandingTeamPoints TeamPoints { get; set; }

        [JsonProperty(PropertyName = "team_standings")]
        public StandingEntry StandingEntry { get; set; }
    }
}
