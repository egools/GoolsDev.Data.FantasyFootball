using Newtonsoft.Json;

namespace YahooFantasyService
{
    public class MatchupTeamPoints : YahooPointsBase
    {
        [JsonProperty(PropertyName = "week")]
        public string Week { get; set; }
    }

}