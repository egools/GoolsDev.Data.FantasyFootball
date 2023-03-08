namespace FantasyRepo.Cosmos.Models
{
    public record Player(
        string PlayerId,
        string PlayerName,
        string EditorialPlayerKey,
        string EditorialTeamKey,
        string EditorialTeamFullName,
        string EditorialTeamAbbr,
        string UniformNumber);
}
