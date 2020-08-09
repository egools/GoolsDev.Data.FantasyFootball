using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static FantasyComponents.Util;

namespace FantasyComponents
{
    [Table("NFLPlayers", Schema = "bmgc")]
    public class NFLPlayer
    {
        public string NFLPlayerID { get; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public NFLPosition NFLPosition { get; set; }
    }
}
