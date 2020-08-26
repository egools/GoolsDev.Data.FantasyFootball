namespace FantasyComponents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Seasons")]
    public class Season
    {
        [Key]
        public int SeasonId { get; }

        public int LeagueId { get; }
        [Required]
        public int Year { get; }
        public string LeagueName { get; }
        public string Settings { get; set; }

        public int SeasonDraftId { get; }
        public SeasonDraft SeasonDraft { get; }
        public ICollection<Matchup> Matchups { get; }
        public ICollection<ManagerSeason> ManagerSeasons { get; }
    }
}
