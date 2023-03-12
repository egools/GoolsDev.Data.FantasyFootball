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
        IEnumerable<Team> Teams);
}