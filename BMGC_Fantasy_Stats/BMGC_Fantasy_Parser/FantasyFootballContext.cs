using FantasyComponents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace FantasyParser
{
    public class FantasyFootballContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("local.appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("sql-bmgc-goolsdev"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<League>()
                .HasMany(l => l.Seasons)
                .WithOne();

            modelBuilder.Entity<Season>()
                .HasMany(s => s.ManagerSeasons)
                .WithOne();

            modelBuilder.Entity<Season>()
                .HasOne(s => s.Draft)
                .WithOne()
                .HasForeignKey<Draft>(d => d.SeasonId);

            modelBuilder.Entity<Season>()
                .HasAlternateKey(s => s.YahooLeagueId);

            modelBuilder.Entity<Season>()
                .HasMany(s => s.Matchups)
                .WithOne();

            modelBuilder.Entity<ManagerSeason>()
                .HasMany(ms => ms.Rosters)
                .WithOne();

            modelBuilder.Entity<ManagerSeason>()
                .HasMany(ms => ms.DraftedPlayers)
                .WithOne();

            modelBuilder.Entity<Manager>()
                .HasMany(m => m.EloScores)
                .WithOne()
                .HasForeignKey(e => e.ManagerId);

            modelBuilder.Entity<Manager>()
                .HasMany(m => m.ManagerSeasons)
                .WithOne()
                .HasForeignKey(ms => ms.ManagerId);

            modelBuilder.Entity<Matchup>()
                .HasOne(m => m.Roster1)
                .WithOne();

            modelBuilder.Entity<Matchup>()
                .HasOne(m => m.Roster2)
                .WithOne();

            modelBuilder.Entity<MatchupRoster>()
                .HasMany(mr => mr.MatchupPlayers)
                .WithOne();

            modelBuilder.Entity<MatchupPlayer>()
                .HasOne(mp => mp.NFLPlayer)
                .WithMany();

            modelBuilder.Entity<DraftedPlayer>()
                .HasOne(dp => dp.NFLPlayer)
                .WithMany();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<League> Leagues { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<ManagerSeason> ManagerSeasons { get; set; }
        public DbSet<Matchup> Matchups { get; set; }
        public DbSet<MatchupRoster> Rosters { get; set; }
        public DbSet<MatchupPlayer> MatchupPlayers { get; set; }
        public DbSet<NFLPlayer> NFLPlayers { get; set; }
        public DbSet<Draft> Drafts { get; set; }
        public DbSet<DraftedPlayer> DraftedPlayers { get; set; }
        public DbSet<EloRating> Ratings { get; set; }
    }
}
