using FantasyFootball.Common.Enums;

namespace FantasyRepo.Cosmos.Models
{
    public record MatchupRoster(
        string MatchupRosterKey, //leaguekey.week.teamkey
        string MatchupKey, //leaguekey.week.combined-teamkeys
        string OpponentKey,
        string TeamKey,
        string LeagueKey,
        string Week,
        string Status,
        bool IsWinner,
        bool IsPlayoffs,
        bool IsConsolation,
        bool IsTied,
        IEnumerable<MatchupPlayer> Players);

    public record MatchupPlayer(
        string PlayerName,
        string PlayerKey,
        double ActualPoints,
        double ProjectedPoints,
        FantasyPosition SelectedPosition,
        PlayerInjuryStatus InjuryStatus,
        IEnumerable<string> EligibilePositions,
        IEnumerable<PlayerStat> Stats);

    public record PlayerStat(
        int StatId,
        double Value);

    public record PlayerInjuryStatus(
        string Status,
        string StatusFull,
        string InjuryNote);
}
