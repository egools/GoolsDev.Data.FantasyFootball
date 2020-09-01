using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyParser.Migrations.FantasyFootball
{
    public partial class InitCreateFromLocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    LeagueId = table.Column<Guid>(nullable: false),
                    LeagueName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.LeagueId);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    YearJoined = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerId);
                });

            migrationBuilder.CreateTable(
                name: "NFLPlayers",
                columns: table => new
                {
                    NFLPlayerId = table.Column<Guid>(nullable: false),
                    YahooId = table.Column<int>(nullable: true),
                    PFRUrl = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: false),
                    NFLPosition = table.Column<int>(nullable: false),
                    Teams = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFLPlayers", x => x.NFLPlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    SeasonId = table.Column<Guid>(nullable: false),
                    Year = table.Column<short>(nullable: false),
                    SeasonLeagueName = table.Column<string>(nullable: false),
                    YahooLeagueId = table.Column<int>(nullable: true),
                    Settings = table.Column<string>(nullable: true),
                    LeagueId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.SeasonId);
                    table.ForeignKey(
                        name: "FK_Seasons_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EloScores",
                columns: table => new
                {
                    EloRatingId = table.Column<Guid>(nullable: false),
                    ManagerId = table.Column<Guid>(nullable: false),
                    Year = table.Column<short>(nullable: false),
                    Week = table.Column<byte>(nullable: false),
                    PreviousRating = table.Column<short>(nullable: false),
                    Change = table.Column<short>(nullable: false),
                    MarginModifier = table.Column<float>(nullable: false),
                    ProjectedModifier = table.Column<float>(nullable: false),
                    PreviousRatingAdjusted = table.Column<short>(nullable: false),
                    ChangeAdjusted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EloScores", x => x.EloRatingId);
                    table.ForeignKey(
                        name: "FK_EloScores_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drafts",
                columns: table => new
                {
                    DraftId = table.Column<Guid>(nullable: false),
                    SeasonId = table.Column<Guid>(nullable: false),
                    DraftType = table.Column<int>(nullable: false),
                    Budget = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drafts", x => x.DraftId);
                    table.ForeignKey(
                        name: "FK_Drafts_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagerSeasons",
                columns: table => new
                {
                    ManagerSeasonId = table.Column<Guid>(nullable: false),
                    TeamName = table.Column<string>(nullable: false),
                    Wins = table.Column<short>(nullable: false),
                    Losses = table.Column<short>(nullable: false),
                    Ties = table.Column<short>(nullable: false),
                    RegularSeasonRank = table.Column<short>(nullable: true),
                    FinalRank = table.Column<short>(nullable: true),
                    MovesMade = table.Column<short>(nullable: true),
                    TradesMade = table.Column<short>(nullable: true),
                    ManagerId = table.Column<Guid>(nullable: true),
                    SeasonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerSeasons", x => x.ManagerSeasonId);
                    table.ForeignKey(
                        name: "FK_ManagerSeasons_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManagerSeasons_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DraftedPlayers",
                columns: table => new
                {
                    DraftedPlayerId = table.Column<Guid>(nullable: false),
                    NFLPlayerId = table.Column<Guid>(nullable: true),
                    Round = table.Column<short>(nullable: true),
                    DraftPosition = table.Column<short>(nullable: true),
                    Price = table.Column<short>(nullable: true),
                    ManagerSeasonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftedPlayers", x => x.DraftedPlayerId);
                    table.ForeignKey(
                        name: "FK_DraftedPlayers_ManagerSeasons_ManagerSeasonId",
                        column: x => x.ManagerSeasonId,
                        principalTable: "ManagerSeasons",
                        principalColumn: "ManagerSeasonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DraftedPlayers_NFLPlayers_NFLPlayerId",
                        column: x => x.NFLPlayerId,
                        principalTable: "NFLPlayers",
                        principalColumn: "NFLPlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchupRosters",
                columns: table => new
                {
                    RosterId = table.Column<Guid>(nullable: false),
                    ActualScore = table.Column<float>(nullable: false),
                    ProjectedScore = table.Column<float>(nullable: false),
                    MatchupId = table.Column<Guid>(nullable: true),
                    ManagerSeasonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchupRosters", x => x.RosterId);
                    table.ForeignKey(
                        name: "FK_MatchupRosters_ManagerSeasons_ManagerSeasonId",
                        column: x => x.ManagerSeasonId,
                        principalTable: "ManagerSeasons",
                        principalColumn: "ManagerSeasonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchupPlayers",
                columns: table => new
                {
                    MatchupPlayerId = table.Column<Guid>(nullable: false),
                    NFLPlayerId = table.Column<Guid>(nullable: false),
                    ProjectedPoints = table.Column<float>(nullable: true),
                    ActualPoints = table.Column<float>(nullable: true),
                    MatchupPosition = table.Column<int>(nullable: false),
                    GameResult = table.Column<string>(nullable: true),
                    StatBlock = table.Column<string>(nullable: true),
                    RosterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchupPlayers", x => x.MatchupPlayerId);
                    table.ForeignKey(
                        name: "FK_MatchupPlayers_NFLPlayers_NFLPlayerId",
                        column: x => x.NFLPlayerId,
                        principalTable: "NFLPlayers",
                        principalColumn: "NFLPlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchupPlayers_MatchupRosters_RosterId",
                        column: x => x.RosterId,
                        principalTable: "MatchupRosters",
                        principalColumn: "RosterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matchups",
                columns: table => new
                {
                    MatchupId = table.Column<Guid>(nullable: false),
                    Week = table.Column<byte>(nullable: false),
                    WinnerId = table.Column<Guid>(nullable: false),
                    Roster1Id = table.Column<Guid>(nullable: true),
                    Roster2Id = table.Column<Guid>(nullable: true),
                    SeasonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchups", x => x.MatchupId);
                    table.ForeignKey(
                        name: "FK_Matchups_MatchupRosters_Roster1Id",
                        column: x => x.Roster1Id,
                        principalTable: "MatchupRosters",
                        principalColumn: "RosterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matchups_MatchupRosters_Roster2Id",
                        column: x => x.Roster2Id,
                        principalTable: "MatchupRosters",
                        principalColumn: "RosterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matchups_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DraftedPlayers_ManagerSeasonId",
                table: "DraftedPlayers",
                column: "ManagerSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftedPlayers_NFLPlayerId",
                table: "DraftedPlayers",
                column: "NFLPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Drafts_SeasonId",
                table: "Drafts",
                column: "SeasonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EloScores_ManagerId",
                table: "EloScores",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerSeasons_ManagerId",
                table: "ManagerSeasons",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerSeasons_SeasonId",
                table: "ManagerSeasons",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchupPlayers_NFLPlayerId",
                table: "MatchupPlayers",
                column: "NFLPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchupPlayers_RosterId",
                table: "MatchupPlayers",
                column: "RosterId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchupRosters_ManagerSeasonId",
                table: "MatchupRosters",
                column: "ManagerSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchupRosters_MatchupId",
                table: "MatchupRosters",
                column: "MatchupId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchups_Roster1Id",
                table: "Matchups",
                column: "Roster1Id",
                unique: true,
                filter: "[Roster1Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Matchups_Roster2Id",
                table: "Matchups",
                column: "Roster2Id",
                unique: true,
                filter: "[Roster2Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Matchups_SeasonId",
                table: "Matchups",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_LeagueId",
                table: "Seasons",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchupRosters_Matchups_MatchupId",
                table: "MatchupRosters",
                column: "MatchupId",
                principalTable: "Matchups",
                principalColumn: "MatchupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchupRosters_ManagerSeasons_ManagerSeasonId",
                table: "MatchupRosters");

            migrationBuilder.DropForeignKey(
                name: "FK_Matchups_Seasons_SeasonId",
                table: "Matchups");

            migrationBuilder.DropForeignKey(
                name: "FK_Matchups_MatchupRosters_Roster1Id",
                table: "Matchups");

            migrationBuilder.DropForeignKey(
                name: "FK_Matchups_MatchupRosters_Roster2Id",
                table: "Matchups");

            migrationBuilder.DropTable(
                name: "DraftedPlayers");

            migrationBuilder.DropTable(
                name: "Drafts");

            migrationBuilder.DropTable(
                name: "EloScores");

            migrationBuilder.DropTable(
                name: "MatchupPlayers");

            migrationBuilder.DropTable(
                name: "NFLPlayers");

            migrationBuilder.DropTable(
                name: "ManagerSeasons");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "MatchupRosters");

            migrationBuilder.DropTable(
                name: "Matchups");
        }
    }
}
