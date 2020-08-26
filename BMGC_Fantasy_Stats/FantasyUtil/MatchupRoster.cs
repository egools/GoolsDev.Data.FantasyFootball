using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyComponents
{
    [Table("MatchupRosters")]
    public class MatchupRoster
    {
        [Key]
        public int RosterID;
        public int MatchupId { get; }
        public Matchup Matchup { get; }
        public int ManagerSeasonId { get; }

        public ICollection<MatchupPlayer> MatchupPlayers { get; }
    }
}
