using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FantasyComponents
{
    [Table("FantasyTeams", Schema = "bmgc")]
    public class FantasyTeam
    {
        public string TeamName { get; set; }
        public Manager Manager { get; set; }
        public Season Season { get; set; }
    }
}
