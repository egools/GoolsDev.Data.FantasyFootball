using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyComponents
{
    [Table("MatchupRosters")]
    public class MatchupRoster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RosterId { get; set; }
        public float ActualScore { get; set; }
        public float ProjectedScore { get; set; }

        [ForeignKey("MatchupId")]
        public Matchup Matchup { get; set; }
        [ForeignKey("RosterId")]
        public ICollection<MatchupPlayer> MatchupPlayers { get; set; }
    }
}
