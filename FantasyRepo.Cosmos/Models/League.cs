using FantasyFootball.Common.Enums;

namespace FantasyRepo.Cosmos.Models
{
    public record League(
        string LeagueId,
        string LeagueKey,
        string LeagueName,
        int Year,
        int CurrentWeek,
        bool IsFinished,
        LeagueSettings Settings,
        Draft Draft,
        IEnumerable<TeamStanding> Standings);

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