using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyComponents
{
    [Table("Rosters", Schema = "ff")]
    public class Roster
    {
        public Roster(string rosterId, float score, float projected)
        {
            RosterId = rosterId;
            ActualScore = score;
            ProjectedScore = projected;
            MatchupPlayers = new List<MatchupPlayer>();
        }

        [Key]
        public string RosterId { get; set; } //[gameKey].l.[yahooLeagueId].t.[teamNum].w.[week]

        public float ActualScore { get; set; }
        public float ProjectedScore { get; set; }

        [ForeignKey("Matchup")]
        public string MatchupId { get; set; }

        [ForeignKey("RosterId")]
        public virtual ICollection<MatchupPlayer> MatchupPlayers { get; set; }
    }
}