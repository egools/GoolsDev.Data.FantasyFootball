using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace YahooFantasyService
{
    public class YahooLeagueApiResult : YahooApiResultBase
    {
        [JsonConstructor]
        public YahooLeagueApiResult(JToken [] league)
        {
            var leagueToken = league.FirstOrDefault();
            var settingsToken = league.Select(j => j.SelectToken("settings[0]")).FirstOrDefault(j => j is not null);
            var draftToken = league.Select(j => j.SelectToken("draft_results")).FirstOrDefault(j => j is not null); //TODO: handle draft deserialization
            var scoreboardToken = league.Select(j => j.SelectToken("scoreboard").FirstOrDefault(j => j is not null)); //TODO: handle scoreboard deserialization
            var standingsToken = league.Select(j => j.SelectToken("standings")).FirstOrDefault(j => j is not null); //TODO: handle standings deserialization

            League = JsonConvert.DeserializeObject<YahooLeague>(leagueToken.ToString());
            League.Settings = JsonConvert.DeserializeObject<LeagueSettings>(settingsToken.ToString());
        }
        public YahooLeague League { get; set; }
    }
}
