using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class StandingTeamPoints : YahooPointsBase
    {
        [JsonProperty(PropertyName = "season")]
        public string Season { get; set; }
    }
}
