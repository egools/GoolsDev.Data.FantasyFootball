using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyComponents
{
    [Table("DraftedPlayers")]
    public class DraftedPlayer
    {
        public int ManagerDraftId { get; }
        public int NFLPlayerId { get; }
        public NFLPlayer NFLPlayer { get; }

        public int? Round { get; }
        public int? DraftPosition { get; }
        public int? Price { get; }
    }
}