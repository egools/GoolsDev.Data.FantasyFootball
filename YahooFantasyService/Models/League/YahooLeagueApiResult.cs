using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace YahooFantasyService
{
    public class YahooLeagueApiResult : YahooApiResultBase
    {
        [JsonConstructor]
        public YahooLeagueApiResult(JToken [] league)
        {
            League = league
                .FirstOrDefault()
                ?.ToObject<YahooLeague>();
            League.Settings = league
                .Select(j => j.SelectToken("settings[0]"))
                .FirstOrDefault(j => j is not null)
                ?.ToObject<LeagueSettings>();
            League.DraftPicks = league
                .Select(j => j.SelectToken("draft_results"))
                .FirstOrDefault(j => j is not null)
                ?.Select(j => j.SelectToken("$..draft_result")
                    ?.ToObject<DraftPick>())
                .Where(d => d is not null)
                .ToList();
            League.Scoreboard = league
                .FirstOrDefault(j => j.SelectToken("scoreboard") is not null)
                ?.ToObject<LeagueScoreboard>();
            League.Standings = league
                .Select(j => j.SelectToken("standings"))
                .FirstOrDefault(j => j is not null)
                ?.ToObject<List<YahooTeamStanding>>(); //TODO: handle standings deserialization
        }
        public YahooLeague League { get; set; }
    }
}
