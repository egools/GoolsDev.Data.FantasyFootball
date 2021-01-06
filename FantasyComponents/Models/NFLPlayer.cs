using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyComponents
{
    [Table("NFLPlayers", Schema = "ff")]
    public class NFLPlayer
    {
        protected NFLPlayer() { }
        public NFLPlayer(string playerId, string fullName, string shortName)
        {
            NFLPlayerId = playerId;
            FullName = fullName;
            ShortName = shortName;
            Teams = new List<TeamTenure>();
        }

        [Key]
        public string NFLPlayerId { get; init; }
        public string PFRUrl { get; set; }
        public string FullName { get; init; }
        public string ShortName { get; set; }
        public string DisplayPosition { get; set; }
        public NFLPosition PrimaryPosition { get; set; }

        [Column("Teams")]
        public string TeamsString { get; set; }

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
            set
            {
                _teams = value;
                TeamsString = string.Join(',', value);
            }
        }
    }

    public record TeamTenure(
        string Team,
        short StartYear,
        short EndYear,
        byte StartWeek,
        byte EndWeek);
}
