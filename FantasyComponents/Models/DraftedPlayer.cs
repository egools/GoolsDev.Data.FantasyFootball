using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyComponents
{
    [Table("DraftedPlayers", Schema = "ff")]
    public class DraftedPlayer
    {
        protected DraftedPlayer()
        {
        }

        public DraftedPlayer(
            string draftedPlayerId,
            short round, short
            draftPosition,
            NFLPlayer nflPlayer,
            short? price = null)
        {
            DraftedPlayerId = draftedPlayerId;
            Round = round;
            DraftPosition = draftPosition;
            Price = price;
            NFLPlayer = nflPlayer;
        }

        [Key]
        public string DraftedPlayerId { get; init; } //[gameKey].l.[yahooLeagueId].[yahooPlayerId]

        [ForeignKey("NFLPlayerId")]
        public virtual NFLPlayer NFLPlayer { get; set; }

        public string TeamId { get; set; }
        public short? Round { get; init; }
        public short? DraftPosition { get; init; }
        public short? Price { get; init; }
        public bool IsKeeper { get; set; }
    }
}