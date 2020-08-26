using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FantasyComponents
{
    [Table("Drafts")]
    public class Draft
    {
        [Key]
        public int DraftId { get; }

        public int ManagerSeasonId { get; }
        public int SeasonDraftId { get; }

        public ICollection<DraftedPlayer> DraftedPlayers { get; }
    }
}