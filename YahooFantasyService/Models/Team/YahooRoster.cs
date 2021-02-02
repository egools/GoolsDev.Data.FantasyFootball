using System.Collections.Generic;

namespace YahooFantasyService
{
    public class YahooRoster : YahooTeamBase
    {
        public string Week { get; set; }
        public bool IsEditable { get; set; }

        public string CoverageType { get; set; }

        public List<YahooRosterPlayer> RosteredPlayers { get; set; }
    }
}
