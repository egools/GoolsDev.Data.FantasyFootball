using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FantasyDAO
{
    [Table("Leagues", Schema = "ff")]
    public class League
    {
        protected League() { }
        public League(string name)
        {
            LeagueId = Guid.NewGuid().ToString();
            LeagueName = name;
            Seasons = new List<Season>();
        }

        [Key]
        public string LeagueId { get; init; }
        public string LeagueName { get; init; } //found in persistent_url if getting current year
        public virtual ICollection<Season> Seasons { get; init; }
    }
}