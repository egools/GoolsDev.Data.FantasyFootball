using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YahooFantasyService
{
    public class YahooTeamApiResult : YahooApiResultBase
    {
        [JsonConstructor]
        public YahooTeamApiResult(JToken [] team)
        {

        }

        public YahooTeamBase Team { get; set; }
    }
}
