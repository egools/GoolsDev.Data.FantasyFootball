using System.Collections.Generic;

namespace YahooFantasyService
{
    public class YahooPlayerBase
    {
        public string PlayerKey { get; set; }
        public string PlayerId { get; set; }
        public YahooPlayerName PlayerName { get; set; }
        public PlayerInjuryStatus InjuryStatus { get; set; }
        public string EditorialPlayerKey { get; set; }
        public string EditorialTeamKey { get; set; }
        public string EditorialTeamFullName { get; set; }
        public string EditorialTeamAbbr { get; set; }
        public List<string> ByeWeeks { get; set; }
        public string UniformNumber { get; set; }
        public string DisplayPosition { get; set; }
        public string IsUndroppable { get; set; }
        public string PositionType { get; set; }
        public List<string> EligibilePositions { get; set; }
        public PlayerStatType StatsType { get; set; }
        public List<PlayerStat> Stats { get; set; }
    }
}
