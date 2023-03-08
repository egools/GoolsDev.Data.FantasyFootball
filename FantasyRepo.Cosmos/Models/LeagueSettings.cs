using FantasyFootball.Common.Enums;

namespace FantasyRepo.Cosmos.Models
{
    public record LeagueSettings(
        DraftType DraftType,
        bool IsAuctionDraft,
        string ScoringType,
        string PersistentUrl,
        bool UsesPlayoff,
        bool HasPlayoffConsolationGames,
        int PlayoffStartWeek,
        bool UsesPlayoffReseeding,
        bool UsesLockEliminatedTeams,
        int NumPlayoffTeams,
        int NumPlayoffConsolationTeams,
        string WaiverType,
        string WaiverRule,
        bool UsesFaab,
        string PostDraftPlayers,
        int WaiverTime,
        DateOnly TradeEndDate,
        DateOnly TradeRatifyType,
        bool UsesFractionalPoints,
        bool UsesNegativePoints,
        IEnumerable<string> Divisions,
        int StartWeek,
        int EndWeek,
        DateTime StartDate,
        DateTime EndDate, 
        string DraftStatus,
        string WeeklyDeadline,
        string LeagueUpdateTimestamp,
        string LeagueType,
        string Renew,
        string Renewed,
        string GameCode,
        int AllowAddToDlExtraPos,
        IEnumerable<RosterPosition> RosterPositions,
        IEnumerable<StatCategory> StatCategories);
}

public record RosterPosition(
    string Position,
    PositionType PositionType,
    int Count);

public record StatCategory(
    int StatId,
    bool Enabled,
    string Name,
    string DisplayName,
    string SortOrder,
    PositionType PositionType,
    bool IsOnlyDisplayStat,
    bool IsExcludedFromDisplay,
    double Modifier,
    IEnumerable<StatBonus> Bonuses,
    IEnumerable<StatPositionType> StatPositionTypes);

public record StatPositionType(
    PositionType PositionType,
    bool IsOnlyDisplayStat);

public record StatBonus(
    int Target,
    double Points);
