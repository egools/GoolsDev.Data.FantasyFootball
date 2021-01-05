using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Security.Policy;

namespace FantasyComponents
{
    [Table("MatchupRosters", Schema = "ff")]
    public class MatchupRoster
    {
        public MatchupRoster()
        {
            MatchupPlayers = new List<MatchupPlayer>();
        }

        [Key]
        public string RosterId { get; set; } //[gameKey].l.[yahooLeagueId].t.[teamNum].[week]
        public float ActualScore { get; set; }
        public float ProjectedScore { get; set; }

        [ForeignKey("Matchup")]
        public string MatchupId { get; set; }

        [ForeignKey("RosterId")]
        public virtual ICollection<MatchupPlayer> MatchupPlayers { get; set; }
    }
}
