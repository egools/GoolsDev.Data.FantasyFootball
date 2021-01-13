using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class YahooTeamStanding : YahooTeamBase
    {
        [JsonPropertyName("team_points")]
        public StandingTeamPoints TeamPoints { get; set; }

        [JsonPropertyName("team_standings")]
        public StandingEntry StandingEntry { get; set; }
    }
}
