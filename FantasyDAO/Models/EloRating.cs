using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FantasyDAO
{
    [Table("EloScores", Schema = "ff")]
    public class EloRating
    {
        protected EloRating() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string EloRatingId { get; set; }
        public string ManagerId { get; set; }
        public string NextEloRatingId { get; set; }
        public short Year { get; set; }
        public byte Week { get; set; }
        public short PreviousRating { get; set; }
        public short Change { get; set; }

        public float MarginModifier { get; set; }
        public float ProjectedModifier { get; set; }
        public short PreviousRatingAdjusted { get; set; }
        public short ChangeAdjusted { get; set; }

    }
}
