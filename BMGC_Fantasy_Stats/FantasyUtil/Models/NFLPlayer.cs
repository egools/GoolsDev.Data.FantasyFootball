using Newtonsoft.Json;
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid NFLPlayerId { get; set; }
        public int? YahooId { get; set; }
        public string PFRUrl { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public NFLPosition NFLPosition { get; set; }
        [Column("Teams")]
        public string TeamsString {get; set;}
        [NotMapped]
        public List<TeamTenure> Teams
        {
            get
            {
                if (Teams == null)
                    return JsonConvert.DeserializeObject<List<TeamTenure>>(TeamsString);
                else 
                    return Teams;
            }
        }
    }

    public struct TeamTenure
    {
        public string Team;
        public short StartYear;
        public short EndYear;
        public byte StartWeek;
        public byte EndWeek;
    }
}
