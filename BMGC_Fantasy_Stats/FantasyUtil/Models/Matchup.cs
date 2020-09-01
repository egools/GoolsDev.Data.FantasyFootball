using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FantasyComponents
{
    [Table("Matchups")]
    public class Matchup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MatchupId { get; set; }
        public byte Week { get; set; }
        public Guid WinnerId { get; set; }

        [ForeignKey("Roster1Id")]
        public MatchupRoster Roster1 { get; set; }
        [ForeignKey("Roster2Id")]
        public MatchupRoster Roster2 { get; set; }
    }
}
