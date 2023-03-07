namespace FantasyRepo.Cosmos.Models
{
    public record SeasonSettingsFull(
        string LeagueId,
        string DraftType,
        bool IsAuctionDraft,
        string ScoringType,
        string PersistentUrl,
        string UsesPlayoff,
        bool HasPlayoffConsolationGames,
        string PlayoffStartWeek,
        int UsesPlayoffReseeding,
        int UsesLockEliminatedTeams,
        string NumPlayoffTeams,
        int NumPlayoffConsolationTeams,
        bool HasMultiweekChampionship,
        string WaiverType,
        string WaiverRule,
        string UsesFaab,
        string DraftTime,
        string DraftPickTime,
        string PostDraftPlayers,
        string MaxTeams,
        string WaiverTime,
        string TradeEndDate,
        string TradeRatifyType,
        string TradeRejectTime,
        string PlayerPool,
        string CantCutList,
        string SendbirdChannelUrl,
        string PickemEnabled,
        string UsesFractionalPoints,
        string UsesNegativePoints,
        IEnumerable<string> Divisions,
        IEnumerable<RosterPosition> RosterPositions,
        IEnumerable<StatCategory> StatCategories);
}

public record RosterPosition(
    string Position,
    string PositionType,
    int Count);


public record StatCategory(
    int StatId,
    string Enabled,
    string Name,
    string DisplayName,
    string SortOrder,
    //PositionType PositionType,
    string IsOnlyDisplayStat,
    string IsExcludedFromDisplay,
    double Modifier,
    IEnumerable<StatBonus> Bonuses,
    IEnumerable<StatPositionType> StatPositionTypes);

public record StatPositionType(
    //PositionType PositionType,
    bool IsOnlyDisplayStat);
public record StatBonus(
    int Target,
    double Points);
