﻿// <auto-generated />
using System;
using FantasyParser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FantasyParser.Migrations.FantasyFootball
{
    [DbContext(typeof(FantasyFootballContext))]
    partial class FantasyFootballContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FantasyComponents.Draft", b =>
                {
                    b.Property<Guid>("DraftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<short?>("Budget")
                        .HasColumnType("smallint");

                    b.Property<int>("DraftType")
                        .HasColumnType("int");

                    b.Property<Guid>("SeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DraftId");

                    b.HasIndex("SeasonId")
                        .IsUnique();

                    b.ToTable("Drafts");
                });

            modelBuilder.Entity("FantasyComponents.DraftedPlayer", b =>
                {
                    b.Property<Guid>("DraftedPlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<short?>("DraftPosition")
                        .HasColumnType("smallint");

                    b.Property<Guid?>("ManagerSeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("NFLPlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short?>("Price")
                        .HasColumnType("smallint");

                    b.Property<short?>("Round")
                        .HasColumnType("smallint");

                    b.HasKey("DraftedPlayerId");

                    b.HasIndex("ManagerSeasonId");

                    b.HasIndex("NFLPlayerId");

                    b.ToTable("DraftedPlayers");
                });

            modelBuilder.Entity("FantasyComponents.EloRating", b =>
                {
                    b.Property<Guid>("EloRatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("Change")
                        .HasColumnType("smallint");

                    b.Property<short>("ChangeAdjusted")
                        .HasColumnType("smallint");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("MarginModifier")
                        .HasColumnType("real");

                    b.Property<short>("PreviousRating")
                        .HasColumnType("smallint");

                    b.Property<short>("PreviousRatingAdjusted")
                        .HasColumnType("smallint");

                    b.Property<float>("ProjectedModifier")
                        .HasColumnType("real");

                    b.Property<byte>("Week")
                        .HasColumnType("tinyint");

                    b.Property<short>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("EloRatingId");

                    b.HasIndex("ManagerId");

                    b.ToTable("EloScores");
                });

            modelBuilder.Entity("FantasyComponents.League", b =>
                {
                    b.Property<Guid>("LeagueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LeagueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LeagueId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("FantasyComponents.Manager", b =>
                {
                    b.Property<Guid>("ManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YahooManagerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<short?>("YearJoined")
                        .HasColumnType("smallint");

                    b.HasKey("ManagerId");

                    b.HasAlternateKey("YahooManagerId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("FantasyComponents.ManagerSeason", b =>
                {
                    b.Property<Guid>("ManagerSeasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<short?>("FinalRank")
                        .HasColumnType("smallint");

                    b.Property<short>("Losses")
                        .HasColumnType("smallint");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short?>("MovesMade")
                        .HasColumnType("smallint");

                    b.Property<short?>("RegularSeasonRank")
                        .HasColumnType("smallint");

                    b.Property<Guid?>("SeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Ties")
                        .HasColumnType("smallint");

                    b.Property<short?>("TradesMade")
                        .HasColumnType("smallint");

                    b.Property<short>("Wins")
                        .HasColumnType("smallint");

                    b.Property<short?>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("ManagerSeasonId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("SeasonId");

                    b.ToTable("ManagerSeasons");
                });

            modelBuilder.Entity("FantasyComponents.Matchup", b =>
                {
                    b.Property<Guid>("MatchupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Roster1Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Roster2Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Week")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("WinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MatchupId");

                    b.HasIndex("Roster1Id")
                        .IsUnique()
                        .HasFilter("[Roster1Id] IS NOT NULL");

                    b.HasIndex("Roster2Id")
                        .IsUnique()
                        .HasFilter("[Roster2Id] IS NOT NULL");

                    b.HasIndex("SeasonId");

                    b.ToTable("Matchups");
                });

            modelBuilder.Entity("FantasyComponents.MatchupPlayer", b =>
                {
                    b.Property<Guid>("MatchupPlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float?>("ActualPoints")
                        .HasColumnType("real");

                    b.Property<string>("GameResult")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MatchupPosition")
                        .HasColumnType("int");

                    b.Property<Guid>("NFLPlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float?>("ProjectedPoints")
                        .HasColumnType("real");

                    b.Property<Guid?>("RosterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StatBlock")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MatchupPlayerId");

                    b.HasIndex("NFLPlayerId");

                    b.HasIndex("RosterId");

                    b.ToTable("MatchupPlayers");
                });

            modelBuilder.Entity("FantasyComponents.MatchupRoster", b =>
                {
                    b.Property<Guid>("RosterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("ActualScore")
                        .HasColumnType("real");

                    b.Property<Guid?>("ManagerSeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MatchupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("ProjectedScore")
                        .HasColumnType("real");

                    b.HasKey("RosterId");

                    b.HasIndex("ManagerSeasonId");

                    b.ToTable("MatchupRosters");
                });

            modelBuilder.Entity("FantasyComponents.NFLPlayer", b =>
                {
                    b.Property<Guid>("NFLPlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NFLPosition")
                        .HasColumnType("int");

                    b.Property<string>("PFRUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamsString")
                        .HasColumnName("Teams")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("YahooId")
                        .HasColumnType("int");

                    b.HasKey("NFLPlayerId");

                    b.ToTable("NFLPlayers");
                });

            modelBuilder.Entity("FantasyComponents.Season", b =>
                {
                    b.Property<Guid>("SeasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LeagueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SeasonLeagueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Settings")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("YahooLeagueId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<short>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("SeasonId");

                    b.HasAlternateKey("YahooLeagueId");

                    b.HasIndex("LeagueId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("FantasyComponents.Draft", b =>
                {
                    b.HasOne("FantasyComponents.Season", null)
                        .WithOne("Draft")
                        .HasForeignKey("FantasyComponents.Draft", "SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FantasyComponents.DraftedPlayer", b =>
                {
                    b.HasOne("FantasyComponents.ManagerSeason", null)
                        .WithMany("DraftedPlayers")
                        .HasForeignKey("ManagerSeasonId");

                    b.HasOne("FantasyComponents.NFLPlayer", "NFLPlayer")
                        .WithMany()
                        .HasForeignKey("NFLPlayerId");
                });

            modelBuilder.Entity("FantasyComponents.EloRating", b =>
                {
                    b.HasOne("FantasyComponents.Manager", null)
                        .WithMany("EloScores")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FantasyComponents.ManagerSeason", b =>
                {
                    b.HasOne("FantasyComponents.Manager", null)
                        .WithMany("ManagerSeasons")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FantasyComponents.Season", null)
                        .WithMany("ManagerSeasons")
                        .HasForeignKey("SeasonId");
                });

            modelBuilder.Entity("FantasyComponents.Matchup", b =>
                {
                    b.HasOne("FantasyComponents.MatchupRoster", "Roster1")
                        .WithOne()
                        .HasForeignKey("FantasyComponents.Matchup", "Roster1Id");

                    b.HasOne("FantasyComponents.MatchupRoster", "Roster2")
                        .WithOne()
                        .HasForeignKey("FantasyComponents.Matchup", "Roster2Id");

                    b.HasOne("FantasyComponents.Season", null)
                        .WithMany("Matchups")
                        .HasForeignKey("SeasonId");
                });

            modelBuilder.Entity("FantasyComponents.MatchupPlayer", b =>
                {
                    b.HasOne("FantasyComponents.NFLPlayer", "NFLPlayer")
                        .WithMany()
                        .HasForeignKey("NFLPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FantasyComponents.MatchupRoster", null)
                        .WithMany("MatchupPlayers")
                        .HasForeignKey("RosterId");
                });

            modelBuilder.Entity("FantasyComponents.MatchupRoster", b =>
                {
                    b.HasOne("FantasyComponents.ManagerSeason", null)
                        .WithMany("Rosters")
                        .HasForeignKey("ManagerSeasonId");
                });

            modelBuilder.Entity("FantasyComponents.Season", b =>
                {
                    b.HasOne("FantasyComponents.League", null)
                        .WithMany("Seasons")
                        .HasForeignKey("LeagueId");
                });
#pragma warning restore 612, 618
        }
    }
}
