using System.Collections.Generic;

namespace YahooFantasyService
{
    public class YahooTeam : YahooTeamBase
    {
        public YahooRoster Roster { get; set; }

        public List<YahooMatchup> Matchups { get; set; }

        public SeasonTeamPoints SeasonPoints { get; set; }

        public WeeklyTeamPoints ActualWeeklyTeamPoints { get; set; }

        public WeeklyTeamPoints ProjectedWeeklyTeamPoints { get; set; }
    }
}
