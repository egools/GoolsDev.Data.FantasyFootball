namespace YahooFantasyService
{
    public class YahooMatchupTeam : YahooTeamBase
    {
        public double WinProbability { get; set; }
        public MatchupTeamPoints TeamPoints { get; set; }
        public MatchupTeamPoints TeamProjectedPoints { get; set; }
    }
}