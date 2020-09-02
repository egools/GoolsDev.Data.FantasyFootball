using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyComponents
{
    [Table("ManagerSeasons")]
    public class ManagerSeason
    {
        private ManagerSeason() { }
        public ManagerSeason(string teamName)
        {
            TeamName = teamName;
            Wins = 0;
            Losses = 0;
            Ties = 0;
            RegularSeasonRank = null;
            FinalRank = null;
            MovesMade = 0;
            TradesMade = 0;
            DraftedPlayers = new List<DraftedPlayer>();
            Rosters = new List<MatchupRoster>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ManagerSeasonId { get; set; }
        public Guid ManagerId { get; set; }
        public short? Year { get; set; }
        public string TeamName { get; set; }
        public short Wins { get; set; }
        public short Losses { get; set; }
        public short Ties { get; set; }
        public short? RegularSeasonRank { get; set; }
        public short? FinalRank { get; set; }
        public short? MovesMade { get; set; }
        public short? TradesMade { get; set; }
        public ICollection<MatchupRoster> Rosters { get; set; }
        public ICollection<DraftedPlayer> DraftedPlayers { get; set; }
    }
}