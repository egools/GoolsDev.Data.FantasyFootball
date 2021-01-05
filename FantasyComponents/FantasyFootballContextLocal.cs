using System;
using System.Collections.Generic;
using System.Text;
using FantasyComponents;
using Microsoft.EntityFrameworkCore;

namespace FantasyComponents
{
    public class FantasyFootballContextLocal : FantasyFootballContext
    {
        public FantasyFootballContextLocal() : base() { }
        public FantasyFootballContextLocal(string leagueName) : base(leagueName) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=localhost;Database=db-goolsdev-prod;Trusted_Connection=True;");
        }

    }
}
