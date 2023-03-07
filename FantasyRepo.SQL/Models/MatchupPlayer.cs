using FantasyFootball.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyRepo.SQL
{
    [Table("MatchupPlayers", Schema = "ff")]
    public class MatchupPlayer : IComparable<MatchupPlayer>
    {
        protected MatchupPlayer() { }
        public MatchupPlayer(
            string matchupPlayerId, 
            NFLPlayer nflPlayer, 
            float? projectedPoints, 
            float? actualPoints, 
            FantasyPosition matchupPosition,
            FantasyPosition eligiblePositions,
            string gameResult,
            string statBlock)
        {
            MatchupPlayerId = matchupPlayerId;
            NFLPlayer = nflPlayer;
            ProjectedPoints = projectedPoints;
            ActualPoints = actualPoints;
            MatchupPosition = matchupPosition;
            EligiblePositions = eligiblePositions;
            GameResult = gameResult;
            StatBlock = statBlock;
        }

        [Key]
        public string MatchupPlayerId { get; init; } //[gameKey].l.[yahooLeagueId].w.[week].p.[playerKey]
        public virtual NFLPlayer NFLPlayer { get; init; }

        public float? ProjectedPoints { get; init; }
        public float? ActualPoints { get; init; }
        public FantasyPosition MatchupPosition { get; init; }
        public FantasyPosition EligiblePositions { get; init; }
        public string GameResult { get; init; }
        public string StatBlock { get; init; }

        public int CompareTo(MatchupPlayer other)
        {
            if (other is null || ActualPoints is null || other.ActualPoints is null)
                return 1;
            else
                return ActualPoints.Value.CompareTo(other.ActualPoints.Value);
        }
    }
}
