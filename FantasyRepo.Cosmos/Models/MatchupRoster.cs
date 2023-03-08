using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FantasyRepo.Cosmos.Models
{
    public record MatchupRoster(
        string MatchupRosterKey, //leaguekey.week.teamkey
        string MatchupKey, //leaguekey.week.combined-teamkeys
        string TeamKey,
        string LeagueKey,
        string Week,
        string Status,
        bool IsPlayoffs,
        bool IsConsolation,
        bool IsTied,
        IEnumerable<MatchupPlayer> Players);

    public record MatchupPlayer(
        double ActualPoints,
        double ProjectedPoints,
        Player Player,
        string PlayerKey,
        string DisplayPosition,
        string PositionType,
        string PrimaryPosition,
        PlayerInjuryStatus InjuryStatus,
        IEnumerable<string> EligibilePositions,
        IEnumerable<string> ByeWeeks,
        IEnumerable<PlayerStat> Stats);

    public record PlayerStat(
        int StatId,
        double Value);

    public record SelectedPosition(
        string Position,
        bool IsFlex);

    public record PlayerInjuryStatus(
        string Status,
        string StatusFull,
        string InjuryNote);
}
