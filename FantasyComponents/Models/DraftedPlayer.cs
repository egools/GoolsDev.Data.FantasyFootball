using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyComponents
{
    [Table("DraftedPlayers", Schema = "ff")]
    public class DraftedPlayer
    {
        protected DraftedPlayer() { }
        public DraftedPlayer(short? round, short? draftPosition, short? price)
        {
            Round = round;
            DraftPosition = draftPosition;
            Price = price;
        }


        [Key]
        public string DraftedPlayerId { get; set; } //[gameKey].l.[yahooLeagueId].[yahooPlayerId]

        [ForeignKey("NFLPlayerId")]
        public virtual NFLPlayer NFLPlayer { get; set; }

        public string TeamId { get; set; }
        public short? Round { get; set; }
        public short? DraftPosition { get; set; }
        public short? Price { get; set; }
        public bool IsKeeper { get; set; }
    }
}
