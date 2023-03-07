using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FantasyRepo.SQL
{
    [Table("Managers", Schema = "ff")]
    public class Manager
    {
        protected Manager() { }
        public Manager(string managerId, string name)
        {
            ManagerId = managerId;
            Name = name;
            ManagerSeasons = new List<Team>();
        }

        [Key]
        public string ManagerId { get; set; } // can be found in standings json
        public string Name { get; set; }
        public virtual ICollection<Team> ManagerSeasons { get; set; }
    }
}
