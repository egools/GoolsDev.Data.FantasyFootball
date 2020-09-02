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
        private League() { }
        public League(string name)
        {
            LeagueId = Guid.NewGuid();
            LeagueName = name;
            Seasons = new List<Season>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LeagueId { get; private set; }
        public string LeagueName { get; private set; }
        public ICollection<Season> Seasons { get; private set; }
    }
}
