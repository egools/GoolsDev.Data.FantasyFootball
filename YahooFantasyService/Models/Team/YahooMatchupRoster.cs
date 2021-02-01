using System.Collections.Generic;

namespace YahooFantasyService
{
    public class YahooMatchupRoster : YahooTeamBase
    {
        public string Week { get; set; }
        public bool IsEditable { get; set; }

        public string CoverageType { get; set; }

        public List<WeeklyMatchupPlayer> RosteredPlayers { get; set; }
    }
}
