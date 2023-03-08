using FantasyFootball.Common.Enums;

namespace FantasyRepo.Cosmos.Models
{
    public record Draft(
        string LeagueKey,
        DraftType DraftType,
        IEnumerable<DraftPick> DraftPicks);

    public record DraftPick(
        int Pick,
        int Round,
        double Cost,
        string TeamKey,
        string TeamName,
        string PlayerKey,
        string PlayerName);
}