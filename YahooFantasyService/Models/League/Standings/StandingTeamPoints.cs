using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class StandingTeamPoints : YahooPointsBase
    {
        [JsonPropertyName("season")]
        public string Season { get; set; }
    }
}
