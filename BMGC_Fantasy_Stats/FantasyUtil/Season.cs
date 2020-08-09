using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyComponents
{
    [Table("Seasons", Schema = "bmgc")]
    public class Season
    {
        public int Year { get; }
        public string LeagueName { get; }

        public Season(int year, string leagueName)
        {
            Year = year;
            LeagueName = leagueName;
        }
    }
}
