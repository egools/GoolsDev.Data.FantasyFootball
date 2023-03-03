using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FantasyComponents
{
    [Table("Matchups", Schema = "ff")]
    public class Matchup
    {
        protected Matchup() { }
        public Matchup(string matchupId, byte week, Roster roster1, Roster roster2)
        {
            MatchupId = matchupId;
            Week = week;
            Roster1 = roster1;
            Roster2 = roster2;
        }

        [Key]
        public string MatchupId { get; init; } //[gameKey].l.[yahooLeagueId].w.[week].t1.[roster1Id].t2.[roster2Id]
        public byte Week { get; init; }

        [NotMapped]
        private string _winnerId;
        public string WinnerId
        {
            get 
            {
                if(_winnerId == default)
                {
                    if (Roster1?.ActualScore > Roster2?.ActualScore)
                        _winnerId = Roster1.RosterId;
                    else if (Roster2?.ActualScore > Roster1?.ActualScore)
                        _winnerId = Roster2.RosterId;
                }
                return _winnerId;
            }
            private set { _winnerId = value; }
        }

        [ForeignKey("Roster1Id")]
        public virtual Roster Roster1 { get; init; }
        [ForeignKey("Roster2Id")]
        public virtual Roster Roster2 { get; init; }
    }
}
