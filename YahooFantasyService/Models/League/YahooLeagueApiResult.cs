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
                .SelectMany(j =>
                    j.SelectTokens("draft_results..draft_result"))
                .Select(j => j.ToObject<DraftPick>())
                .ToList();
            League.Scoreboard = league
                .FirstOrDefault(j => j.SelectToken("scoreboard") is not null)
                ?.ToObject<LeagueScoreboard>();
            League.Standings = league
                .SelectMany(j => j.SelectTokens("standings[*].teams..team"))
                .Select(j => YahooTeamStanding.FromJTokens(j.Children().ToList()))
                .ToList();
        }
        public YahooLeague League { get; set; }
    }
}
