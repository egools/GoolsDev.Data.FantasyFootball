namespace FantasyDAO
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Seasons", Schema = "ff")]
    public class Season
    {
        protected Season()
        {
        }

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
        public List<Division> Divisions { get; set; }
        public int StartWeek { get; set; }
        public int EndWeek { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PlayoffTeams { get; set; }
        public int PlayoffStartWeek { get; set; }
        public bool HasConsolations { get; set; }
        public int ConsolationTeams { get; set; }
        public bool UsePlayoffReseeding { get; set; }
        public bool UseFractionalPoints { get; set; }
        public bool UseNegativePoints { get; set; }
        public bool UsesFaab { get; set; }
        public string WaiverRule { get; set; }
        public string WaiverType { get; set; }
        public Dictionary<int, StatModifier> StatModifiers { get; set; }
        public List<RosterPosition> RosterPositions { get; set; }
    }

    [NotMapped]
    public class Division
    {
        public int DivisionId { get; set; }
        public string Name { get; set; }
    }

    [NotMapped]
    public class StatModifier
    {
        public int StatId { get; set; }
        public string StatName { get; set; }
        public string StatDisplayName { get; set; }
        public float Value { get; set; }
        public bool Enabled { get; set; }
        public bool IsDisplayOnly { get; set; }
        public List<StatPositionType> PositionTypes { get; set; }
        public List<StatBonus> Bonuses { get; set; }
    }

    [NotMapped]
    public class StatBonus
    {
        public double BonusThreshold { get; set; }
        public double BonusAmount { get; set; }
    }

    [NotMapped]
    public class RosterPosition
    {
        public FantasyPosition Position { get; set; }
        public PositionType PositionType { get; set; }
        public int PositionCount { get; set; }
    }

    [NotMapped]
    public class StatPositionType
    {
        public PositionType PositionType { get; set; }

        public bool IsDisplayOnly { get; set; }
    }
}