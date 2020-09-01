using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static FantasyComponents.Util;

namespace FantasyComponents
{
    [Table("Drafts")]
    public class Draft
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DraftId { get; set; }
        public Guid SeasonId { get; set; }
        public DraftType DraftType { get; set; }
        public short? Budget { get; set; }

        public Draft(Guid seasonId)
        {
            DraftType = DraftType.Snake;
            SeasonId = seasonId;
        }

        public Draft(Guid seasonId, DraftType draftType)
        {
            DraftType = draftType;
            SeasonId = seasonId;
        }

        [Column("DraftOrder")]
        private string DraftOrderString { get; set; }

        private List<int> _draftOrder;
        [NotMapped]
        public List<int> DraftOrder { 
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
    }
}