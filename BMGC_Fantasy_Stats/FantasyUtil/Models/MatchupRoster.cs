using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace FantasyComponents
{
    [Table("MatchupRosters")]
    public class MatchupRoster
    {
        public MatchupRoster()
        {
            MatchupPlayers = new List<MatchupPlayer>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RosterId { get; set; }
        public float ActualScore { get; set; }
        public float ProjectedScore { get; set; }

        [ForeignKey("Matchup")]
        public Guid MatchupId { get; set; }
        [ForeignKey("RosterId")]
        public ICollection<MatchupPlayer> MatchupPlayers { get; set; }
    }
}
