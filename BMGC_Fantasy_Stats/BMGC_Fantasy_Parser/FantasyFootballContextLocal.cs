using System;
using System.Collections.Generic;
using System.Text;
using FantasyComponents;
using Microsoft.EntityFrameworkCore;

namespace FantasyParser
{
    public class FantasyFootballContextLocal : FantasyFootballContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=FantasyFootball;Trusted_Connection=True;");
        }

    }
}
