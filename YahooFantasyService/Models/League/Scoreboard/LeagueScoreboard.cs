using Newtonsoft.Json;
using System.Collections.Generic;

namespace YahooFantasyService
{
    public class LeagueScoreboard
    {
        [JsonProperty(PropertyName ="week")]
        public int Week { get; set; }

        public List<YahooMatchup> Matchups { get; set; }
    }
}
