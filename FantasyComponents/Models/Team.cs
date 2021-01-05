using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyComponents
{
    [Table("Team", Schema = "ff")]
    public class Team
    {
        protected Team() { }
        public Team(string teamName, short year)
        {
            TeamName = teamName;
            Year = year;
            Wins = 0;
            Losses = 0;
            Ties = 0;
            WinsDivision = 0;
            LossesDivision = 0;
            TiesDivision = 0;
            MadePlayoffs = null;
            RegularSeasonRank = null;
            PlayoffSeed = null;
            FinalRank = null;
            MovesMade = 0;
            TradesMade = 0;
            SeasonRating = 0;
            NameRating = null;
            Rosters = new List<MatchupRoster>();
            DraftedPlayers = new List<DraftedPlayer>();
        }

        [Key]
        public string TeamId { get; init; } //[gameKey].l.[yahooLeagueId].t.[teamNum]
        public string ManagerId { get; init; }
        public string SeasonId { get; init; } //[gameKey].l.[yahooLeagueId]
        public string TeamName { get; set; }
        public short Year { get; init; }
        public short Wins { get; set; }
        public short Losses { get; set; }
        public short Ties { get; set; }
        public short? WinsDivision { get; set; }
        public short? LossesDivision { get; set; }
        public short? TiesDivision { get; set; }
        public bool? MadePlayoffs { get; set; }
        public short? RegularSeasonRank { get; set; }
        public short? PlayoffSeed { get; set; }
        public short? FinalRank { get; set; }
        public short MovesMade { get; set; }
        public short TradesMade { get; set; }
        public int SeasonRating { get; set; }
        public int? NameRating { get; set; }
        public virtual ICollection<MatchupRoster> Rosters { get; set; }
        public virtual ICollection<DraftedPlayer> DraftedPlayers { get; set; }
    }
}