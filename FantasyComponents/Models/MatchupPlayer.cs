using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyComponents
{
    [Table("MatchupPlayers", Schema = "ff")]
    public class MatchupPlayer : IComparable<MatchupPlayer>
    {
        protected MatchupPlayer() { }
        public MatchupPlayer(NFLPlayer nflPlayer, float? projectedPoints, float? actualPoints, FantasyPosition matchupPosition)
        {
            MatchupPlayerId = Guid.NewGuid().ToString();
            NFLPlayer = nflPlayer;
            ProjectedPoints = projectedPoints;
            ActualPoints = actualPoints;
            MatchupPosition = matchupPosition;
        }

        [Key]
        public string MatchupPlayerId { get; init; }
        public virtual NFLPlayer NFLPlayer { get; set; }

        public float? ProjectedPoints { get; set; }
        public float? ActualPoints { get; set; }
        public FantasyPosition MatchupPosition { get; set; }
        public FantasyPosition EligiblePositions { get; set; }
        public string GameResult { get; set; }
        public string StatBlock { get; set; }

        public int CompareTo(MatchupPlayer other)
        {
            if (other is null || ActualPoints is null || other.ActualPoints is null)
                return 1;
            else
                return ActualPoints.Value.CompareTo(other.ActualPoints.Value);
        }
    }
}
