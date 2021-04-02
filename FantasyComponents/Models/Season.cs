namespace FantasyComponents
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Security.Policy;
    using System.Text.RegularExpressions;

    [Table("Seasons", Schema = "ff")]
    public class Season
    {
        protected Season() { }
        public Season(short year, string seasonId, string seasonName, Settings settings)
        {
            SeasonId = seasonId;
            Year = year;
            SeasonLeagueName = seasonName;
            Settings = settings;
            Matchups = new List<Matchup>();
            Teams = new List<Team>();
        }

        [Key]
        public string SeasonId { get; init; } //[gameKey].l.[yahooLeagueId]
        public short Year { get; init; }
        public string SeasonLeagueName { get; init; }

        [Column("Settings")]
        public string SettingsJson { get; set; }

        [NotMapped]
        public Settings Settings
        {
            get => string.IsNullOrEmpty(SettingsJson) ? null : JsonConvert.DeserializeObject<Settings>(SettingsJson);
            set => SettingsJson = JsonConvert.SerializeObject(value);
        }

        [ForeignKey("DraftId")]
        public virtual Draft Draft { get; set; }
        public virtual ICollection<Matchup> Matchups { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }

    [NotMapped]
    public class Settings
    {
        public List<string> Divisions { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PlayoffTeams { get; set; }
        public int PlayoffStartWeek { get; set; }
        public bool HasConsolations { get; set; }
        public bool UseFractionalPoints { get; set; }
        public bool UseNegativePoints { get; set; }
        public List<StatModifier> StatModifiers { get; set; }
        public List<RosterPosition> RosterPositions { get; set; }
    }

    [NotMapped]
    public class StatModifier
    {
        public int StatId { get; set; }
        public string StatName { get; set; }
        public string StatDisplayName { get; set; }
        public float Value { get; set; }
        public float BonusThreshold { get; set; }
        public float BonusAmount { get; set; }
        public bool Enabled { get; set; }
    }

    [NotMapped]
    public class RosterPosition
    {
        public FantasyPosition Position { get; set; }
        public int PositionCount { get; set; }
    }
}
