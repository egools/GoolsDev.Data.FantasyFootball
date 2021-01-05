using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace FantasyComponents
{
    public class FantasyFootballContext : DbContext
    {
        protected readonly string LeagueName;
        public FantasyFootballContext() : base() { }
        public FantasyFootballContext(string leagueName) : base()
        {
            LeagueName = leagueName;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("local.appsettings.json")
                .Build();
            optionsBuilder
                .UseSqlServer(configuration.GetConnectionString("db-goolsdev-prod"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<League>().HasQueryFilter(l => l.LeagueName == LeagueName);

            modelBuilder.Entity<League>()
                .HasMany(l => l.Seasons)
                .WithOne();

            modelBuilder.Entity<Season>()
                .HasMany(s => s.Teams)
                .WithOne();

            modelBuilder.Entity<Season>()
                .HasOne(s => s.Draft)
                .WithOne();

            modelBuilder.Entity<Draft>()
                .HasMany(d => d.DraftedPlayers)
                .WithOne();

            modelBuilder.Entity<Season>()
                .HasMany(s => s.Matchups)
                .WithOne();

            modelBuilder.Entity<Team>()
                .HasMany(ms => ms.Rosters)
                .WithOne();

            modelBuilder.Entity<Team>()
                .HasMany(ms => ms.DraftedPlayers)
                .WithOne()
                .HasForeignKey(dp => dp.TeamId);

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
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Matchup> Matchups { get; set; }
        public DbSet<MatchupRoster> Rosters { get; set; }
        public DbSet<MatchupPlayer> MatchupPlayers { get; set; }
        public DbSet<NFLPlayer> NFLPlayers { get; set; }
        public DbSet<Draft> Drafts { get; set; }
        public DbSet<DraftedPlayer> DraftedPlayers { get; set; }
        public DbSet<EloRating> Ratings { get; set; }
    }
}
