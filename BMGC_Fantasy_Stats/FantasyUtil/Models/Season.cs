namespace FantasyComponents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text.RegularExpressions;

    [Table("Seasons")]
    public class Season
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SeasonId { get; private set; }
        public short Year { get; private set; }
        public string SeasonLeagueName { get; private set; }
        public int? YahooLeagueId { get; private set; }
        public string? Settings { get; set; }
        public Draft? Draft { get; set; }
        public ICollection<Matchup> Matchups { get; set; }
        public ICollection<ManagerSeason> ManagerSeasons { get; set; }

        private Season()
        {
            //SeasonId = Guid.NewGuid();
            Matchups = new List<Matchup>();
            ManagerSeasons = new List<ManagerSeason>();
        }

        public Season(short year)
        {
            //SeasonId = Guid.NewGuid();
            Year = year;
            Matchups = new List<Matchup>();
            ManagerSeasons = new List<ManagerSeason>();
        }

        public void CreateSettings()
        {
        }
    }
}
