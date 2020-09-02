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
        private NFLPlayer() { }
        public NFLPlayer(int? yahooId, string fullName, string shortName)
        {
            YahooId = yahooId;
            FullName = fullName;
            ShortName = shortName;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid NFLPlayerId { get; set; }
        public int? YahooId { get; set; }
        public string? PFRUrl { get; set; }
        public string FullName { get; set; }
        public string? ShortName { get; set; }
        public NFLPosition NFLPosition { get; set; }
        [Column("Teams")]
        public string? TeamsString { get; set; }

        [NotMapped]
        private List<TeamTenure> _teams;
        [NotMapped]
        public List<TeamTenure> Teams
        {
            get
            {
                if (string.IsNullOrWhiteSpace(TeamsString))
                    return new List<TeamTenure>();
                else if (_teams == null)
                    return JsonConvert.DeserializeObject<List<TeamTenure>>(TeamsString);
                else
                    return _teams;
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
