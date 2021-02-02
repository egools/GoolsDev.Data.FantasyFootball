using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace YahooFantasyService
{
    public class YahooTeamApiResult : YahooApiResultBase
    {
        [JsonConstructor]
        public YahooTeamApiResult(JToken[] team)
        {
            var baseTeamToken = team.Length < 2
                ? new JObject()
                : team[1];
            Team = baseTeamToken.AbsorbTokenProperties(team[0]).ToObject<YahooTeam>();
            Team.Matchups = team.SelectMany(j => j.SelectTokens("..matchups..matchup"))
                ?.Select(j => j.ToObject<YahooMatchup>())
                ?.ToList();
        }

        public YahooTeam Team { get; set; }
    }
}
