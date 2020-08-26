using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FantasyComponents
{
    [Table("Leagues")]
    public class League
    {

        [Key]
        public int LeagueId { get; }
        public string LeagueName { get; }
        public ICollection<Season> Seasons { get; }


    }
}
