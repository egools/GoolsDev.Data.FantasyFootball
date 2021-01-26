using System.Collections.Generic;

namespace YahooFantasyService
{
    public class YahooPlayerCollectionApiResult : YahooApiResultBase
    {
        public List<YahooPlayerBase> Players { get; set; }
    }
}
