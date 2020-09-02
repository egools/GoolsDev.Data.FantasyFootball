using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyComponents
{
    [Table("DraftedPlayers")]
    public class DraftedPlayer
    {
        private DraftedPlayer() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DraftedPlayerId { get; set; }
        [ForeignKey("NFLPlayerId")]
        public NFLPlayer NFLPlayer { get; set; }

        public short? Round { get; set; }
        public short? DraftPosition { get; set; }
        public short? Price { get; set; }
    }
}