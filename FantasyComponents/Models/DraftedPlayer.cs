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
            string teamId,
            short round, short
            draftPosition,
            short? price = null)
        {
            DraftedPlayerId = draftedPlayerId;
            TeamId = teamId;
            Round = round;
            DraftPosition = draftPosition;
            Price = price;
        }

        [Key]
        public string DraftedPlayerId { get; init; } //[gameKey].l.[yahooLeagueId].t.[teamId].p.[yahooPlayerId]

        [ForeignKey("NFLPlayerId")]
        public virtual NFLPlayer NFLPlayer { get; set; }

        public string TeamId { get; init; }
        public short? Round { get; init; }
        public short? DraftPosition { get; init; }
        public short? Price { get; init; }
        public bool IsKeeper { get; set; }
    }
}