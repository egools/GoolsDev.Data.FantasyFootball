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
        public string NFLPlayerId { get; init; } //[gameKey].p.[playerId]
        public string PFRUrl { get; set; }
        public string FullName { get; init; }
        public string ShortName { get; init; }
        public string DisplayPosition { get; init; }
        public NFLPosition PrimaryPosition { get; init; }

        [Column("Teams")]
        private string TeamsString { get; set; }

        [NotMapped]
        private List<TeamTenure> _teams;
        [NotMapped]
        public List<TeamTenure> Teams
        {
            get
            {
                return _teams ?? (string.IsNullOrEmpty(TeamsString) ? null : JsonConvert.DeserializeObject<List<TeamTenure>>(TeamsString));
            }
            set
            {
                TeamsString = JsonConvert.SerializeObject(value);
                _teams = value;
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
