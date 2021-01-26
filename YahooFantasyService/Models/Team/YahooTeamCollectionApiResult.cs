using System.Collections.Generic;

namespace YahooFantasyService
{
    public class YahooTeamCollectionApiResult : YahooApiResultBase
    {
        public List<YahooTeamBase> Teams { get; set; }
    }
}
