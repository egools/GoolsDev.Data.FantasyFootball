using System.Collections.Generic;

namespace YahooFantasyService
{
    public class YahooLeagueStandings : YahooLeagueBase
    {
        public List<YahooTeamStanding> Standings { get; set; }
    }
}
