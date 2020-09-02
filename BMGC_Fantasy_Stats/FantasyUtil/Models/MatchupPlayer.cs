using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FantasyComponents.Util;

namespace FantasyComponents
{
    [Table("MatchupPlayers")]
    public class MatchupPlayer : IComparable<MatchupPlayer>
    {
        private MatchupPlayer() { }
        public MatchupPlayer(NFLPlayer nFLPlayer, float? projectedPoints, float? actualPoints, FantasyPosition matchupPosition)
        {
            NFLPlayer = nFLPlayer;
            ProjectedPoints = projectedPoints;
            ActualPoints = actualPoints;
            MatchupPosition = matchupPosition;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MatchupPlayerId { get; set; }
        public NFLPlayer NFLPlayer { get; set; }

        public float? ProjectedPoints { get; set; }
        public float? ActualPoints { get; set; }
        public FantasyPosition MatchupPosition { get; set; }
        public string? GameResult { get; set; }
        public string? StatBlock { get; set; }

        public int CompareTo(MatchupPlayer? other)
        {
            if (other is null || ActualPoints is null || other.ActualPoints is null)
                return 1;
            else
                return ActualPoints.Value.CompareTo(other.ActualPoints.Value);
        }
    }
}
