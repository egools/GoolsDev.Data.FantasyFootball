using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YahooFantasyService
{
    public class YahooApiResultBase
    {
        [JsonPropertyName("xml:lang")]
        public string XmlLang { get; set; }

        [JsonPropertyName("yahoo:uri")]
        public string YahooUri { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("refresh_rate")]
        public string RefreshRate { get; set; }
    }

    public class YahooLeagueApiResult : YahooApiResultBase
    {
        public YahooLeague League { get; set; }

        [JsonPropertyName("league")]
        public object[] LeagueObjectCollection { get; set; }
    }

    public class YahooLeagueCollectionApiResult : YahooApiResultBase
    {
        public List<YahooLeague> Leagues { get; set; }

        public object[] LeaguesObjectCollection { get; set; }
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
        public YahooPlayerBase Player { get; set; }
    }

    public class YahooPlayerCollectionApiResult : YahooApiResultBase
    {
        public List<YahooPlayerBase> Players { get; set; }
    }
}
