using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FantasyComponents
{
    [Table("Managers")]
    public class Manager
    {
        private Manager() { }
        public Manager(string yahooManagerId, string name)
        {
            YahooManagerId = yahooManagerId;
            Name = name;
            EloScores = new List<EloRating>();
            ManagerSeasons = new List<ManagerSeason>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ManagerId { get; set; }
        public string YahooManagerId { get; set; }
        public string Name { get; set; }
        public short? YearJoined { get; set; }
        public ICollection<EloRating> EloScores { get; set; }
        public ICollection<ManagerSeason> ManagerSeasons { get; set; }
    }
}
