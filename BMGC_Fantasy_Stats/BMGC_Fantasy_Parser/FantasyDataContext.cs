using System;
using System.Collections.Generic;
using System.Text;
using FantasyComponents;
using Microsoft.EntityFrameworkCore;

namespace FantasyParser
{
    public class FantasyDataContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=BMGCFantasy;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
