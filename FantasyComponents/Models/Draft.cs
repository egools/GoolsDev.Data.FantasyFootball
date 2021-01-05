using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static FantasyComponents.Util;

namespace FantasyComponents
{
    [Table("Drafts", Schema ="ff")]
    public class Draft
    {
        protected Draft() { }
        public Draft(string draftId, DraftType draftType)
        {
            DraftId = draftId;
            DraftType = draftType;
        }

        [Key]
        public string DraftId { get; init; } //[gameKey].l.[yahooLeagueId]
        public DraftType DraftType { get; init; }
        public short? Budget { get; init; }

        [Column("DraftOrder")]
        private string DraftOrderString { get; set; }

        private List<int> _draftOrder;
        [NotMapped]
        public List<int> DraftOrder
        {
            get
            {
                return _draftOrder ?? DraftOrderString?.Split(",").Select(i => int.Parse(i)).ToList() ?? new List<int>();
            }
            set
            {
                DraftOrderString = string.Join(',', value);
                _draftOrder = value;
            }
        }

        public virtual ICollection<DraftedPlayer> DraftedPlayers { get; set; }
    }
}