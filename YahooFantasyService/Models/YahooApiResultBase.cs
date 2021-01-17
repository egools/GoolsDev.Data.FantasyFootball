using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace YahooFantasyService
{
    public class YahooApiResultBase
    {
        [JsonProperty(PropertyName = "xml:lang")]
        public string XmlLang { get; set; }

        [JsonProperty(PropertyName = "yahoo:uri")]
        public string YahooUri { get; set; }

        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }

        [JsonProperty(PropertyName = "refresh_rate")]
        public string RefreshRate { get; set; }
    }

    public class YahooLeagueApiResult : YahooApiResultBase
    {
        [JsonConstructor]
        public YahooLeagueApiResult(JToken [] league)
        {

        }
        public YahooLeague League { get; set; }
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
