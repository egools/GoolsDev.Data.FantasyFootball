using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FantasyComponents
{
    [Table("Matchups")]
    public class Matchup
    {
        [Key]
        public int MatchupId { get;}
        public int SeasonId { get; }
        public Season Season { get;}

        [ForeignKey("RosterId")]
        public int Roster1Id { get; }
        public MatchupRoster Roster1 { get; }

        [ForeignKey("RosterId")]
        public int Roster2Id { get; }
        public MatchupRoster Roster2 { get; }
        public int Week { get; }
        public int WinnerId { get; }
    }
}
