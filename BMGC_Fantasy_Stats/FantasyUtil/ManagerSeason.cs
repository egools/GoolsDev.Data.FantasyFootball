using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyComponents
{
    [Table("ManagerSeasons")]
    public class ManagerSeason
    {
        [Key]
        public int ManagerSeasonId { get; }

        public int ManagerId { get; }
        public Manager Manager { get; }
        public int SeasonId { get; }
        public Season Season { get; }
        public int DraftId { get; }
        public Draft Draft { get; }


        public string TeamName { get; }
        public int MovesMade { get; }
        public int TradesMade { get; }
        public ICollection<MatchupRoster> Rosters { get; }
    }
}