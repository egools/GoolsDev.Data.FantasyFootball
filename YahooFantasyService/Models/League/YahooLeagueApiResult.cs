using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YahooFantasyService
{
    public class YahooLeagueApiResult : YahooApiResultBase
    {
        [JsonConstructor]
        public YahooLeagueApiResult(JToken [] league)
        {

        }
        public YahooLeague League { get; set; }
    }
}
