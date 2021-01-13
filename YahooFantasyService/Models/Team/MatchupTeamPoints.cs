using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class MatchupTeamPoints : YahooPointsBase
    {
        [JsonPropertyName("week")]
        public string Week { get; set; }
    }

}