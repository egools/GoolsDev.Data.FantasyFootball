namespace FantasyRepo.Cosmos.Models
{
    public record Season(
        string SeasonId,
        string SeasonName,
        int Year,
        IEnumerable<TeamStanding> Standings);

    public record SeasonSettings();

    public record TeamStanding(
        StandingsRecord OverallRecord,
        StandingsRecord DivisionRecord,
        int Rank = 1,
        int Streak = 0,
        double PointsFor = 0,
        double PointsAgainst = 0);

    public record StandingsRecord(
        int Wins = 0,
        int Losses = 0,
        int Ties = 0)
    {
        public readonly double WinPercentage = Wins / (Wins + Losses + Ties);
    }
}
