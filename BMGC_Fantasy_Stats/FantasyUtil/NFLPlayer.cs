using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static FantasyComponents.Util;

namespace FantasyComponents
{
    [Table("NFLPlayers")]
    public class NFLPlayer
    {
        [Key]
        public int NFLPlayerId { get; }
        public int? YahooId { get; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public NFLPosition NFLPosition { get; set; }
    }
}
