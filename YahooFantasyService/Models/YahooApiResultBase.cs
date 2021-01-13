using System.Collections.Generic;

namespace YahooFantasyService
{
    public class YahooApiResultBase
    {
        public string XmlLang { get; set; }
        public string YahooUri { get; set; }
        public string Time { get; set; }
        public string Copyright { get; set; }
        public string RefreshRate { get; set; }
    }

    public class YahooApiLeagueResult : YahooApiResultBase
    {
        public YahooLeagueBase League { get; set; }
    }

    public class YahooLeagueCollectionApiResult : YahooApiResultBase
    {
        public List<YahooLeagueBase> Teams { get; set; }
    }

    public class YahooTeamApiResult : YahooApiResultBase
    {
        public YahooTeamBase Team { get; set; }
    }

    public class YahooTeamCollectionApiResult : YahooApiResultBase
    {
        public List<YahooTeamBase> Teams { get; set; }
    }

    public class YahooPlayerApiResult : YahooApiResultBase
    {
        public YahooPlayerBase Players { get; set; }
    }

    public class YahooPlayerCollectionApiResult : YahooApiResultBase
    {
        public List<YahooPlayerBase> Teams { get; set; }
    }
}
