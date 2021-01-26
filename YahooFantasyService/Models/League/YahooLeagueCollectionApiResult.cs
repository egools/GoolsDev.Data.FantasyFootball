using System.Collections.Generic;

namespace YahooFantasyService
{
    public class YahooLeagueCollectionApiResult : YahooApiResultBase
    {
        public List<YahooLeague> Leagues { get; set; }

        public object[] LeaguesObjectCollection { get; set; }
    }
}
