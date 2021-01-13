using System.Collections.Generic;

namespace YahooFantasyService
{
    public class LeagueScoreboard
    {
        public int Week { get; set; }
        public List<YahooMatchup> Matchups { get; set; }
    }
}
