using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyComponents
{
    [Table("SeasonDrafts")]
    public class SeasonDraft
    {
        [Key]
        public int SeasonDraftId { get; }
        public int DraftType { get; }
        public List<int> DraftOrder { get; }
        public int Budget { get; }

        public int SeasonId { get; }
        public Season Season { get; }
    }
}