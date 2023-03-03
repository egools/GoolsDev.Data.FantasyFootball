using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyDAO.Migrations
{
    public partial class Update_Ids_To_String : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ff");

            migrationBuilder.CreateTable(
                name: "EloScores",
                schema: "ff",
                columns: table => new
                {
                    EloRatingId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ManagerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextEloRatingId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    Week = table.Column<byte>(type: "tinyint", nullable: false),
                    PreviousRating = table.Column<short>(type: "smallint", nullable: false),
                    Change = table.Column<short>(type: "smallint", nullable: false),
                    MarginModifier = table.Column<float>(type: "real", nullable: false),
                    ProjectedModifier = table.Column<float>(type: "real", nullable: false),
                    PreviousRatingAdjusted = table.Column<short>(type: "smallint", nullable: false),
                    ChangeAdjusted = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EloScores", x => x.EloRatingId);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                schema: "ff",
                columns: table => new
                {
                    LeagueId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LeagueName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.LeagueId);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                schema: "ff",
                columns: table => new
                {
                    ManagerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerId);
                });

            migrationBuilder.CreateTable(
                name: "NFLPlayers",
                schema: "ff",
                columns: table => new
                {
                    NFLPlayerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YahooId = table.Column<int>(type: "int", nullable: true),
                    PFRUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NFLPosition = table.Column<int>(type: "int", nullable: false),
                    Teams = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFLPlayers", x => x.NFLPlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                schema: "ff",
                columns: table => new
                {
                    SeasonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    SeasonLeagueName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YahooLeagueId = table.Column<int>(type: "int", nullable: false),
                    Settings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeagueId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.SeasonId);
                    table.UniqueConstraint("AK_Seasons_YahooLeagueId", x => x.YahooLeagueId);
                    table.ForeignKey(
                        name: "FK_Seasons_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalSchema: "ff",
                        principalTable: "Leagues",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drafts",
                schema: "ff",
                columns: table => new
                {
                    DraftId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SeasonId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DraftType = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drafts", x => x.DraftId);
                    table.ForeignKey(
                        name: "FK_Drafts_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalSchema: "ff",
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManagerSeasons",
                schema: "ff",
                columns: table => new
                {
                    TeamId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ManagerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SeasonId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wins = table.Column<short>(type: "smallint", nullable: false),
                    Losses = table.Column<short>(type: "smallint", nullable: false),
                    Ties = table.Column<short>(type: "smallint", nullable: false),
                    MadePlayoffs = table.Column<bool>(type: "bit", nullable: true),
                    RegularSeasonRank = table.Column<short>(type: "smallint", nullable: true),
                    FinalRank = table.Column<short>(type: "smallint", nullable: true),
                    MovesMade = table.Column<short>(type: "smallint", nullable: false),
                    TradesMade = table.Column<short>(type: "smallint", nullable: false),
                    SeasonRating = table.Column<int>(type: "int", nullable: false),
                    NameRating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerSeasons", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_ManagerSeasons_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalSchema: "ff",
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManagerSeasons_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalSchema: "ff",
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DraftedPlayers",
                schema: "ff",
                columns: table => new
                {
                    DraftedPlayerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NFLPlayerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Round = table.Column<short>(type: "smallint", nullable: true),
                    DraftPosition = table.Column<short>(type: "smallint", nullable: true),
                    Price = table.Column<short>(type: "smallint", nullable: true),
                    IsKeeper = table.Column<bool>(type: "bit", nullable: false),
                    TeamId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftedPlayers", x => x.DraftedPlayerId);
                    table.ForeignKey(
                        name: "FK_DraftedPlayers_ManagerSeasons_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "ff",
                        principalTable: "ManagerSeasons",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DraftedPlayers_NFLPlayers_NFLPlayerId",
                        column: x => x.NFLPlayerId,
                        principalSchema: "ff",
                        principalTable: "NFLPlayers",
                        principalColumn: "NFLPlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchupRosters",
                schema: "ff",
                columns: table => new
                {
                    RosterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActualScore = table.Column<float>(type: "real", nullable: false),
                    ProjectedScore = table.Column<float>(type: "real", nullable: false),
                    MatchupId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchupRosters", x => x.RosterId);
                    table.ForeignKey(
                        name: "FK_MatchupRosters_ManagerSeasons_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "ff",
                        principalTable: "ManagerSeasons",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchupPlayers",
                schema: "ff",
                columns: table => new
                {
                    MatchupPlayerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NFLPlayerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProjectedPoints = table.Column<float>(type: "real", nullable: true),
                    ActualPoints = table.Column<float>(type: "real", nullable: true),
                    MatchupPosition = table.Column<int>(type: "int", nullable: false),
                    GameResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatBlock = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RosterId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchupPlayers", x => x.MatchupPlayerId);
                    table.ForeignKey(
                        name: "FK_MatchupPlayers_MatchupRosters_RosterId",
                        column: x => x.RosterId,
                        principalSchema: "ff",
                        principalTable: "MatchupRosters",
                        principalColumn: "RosterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchupPlayers_NFLPlayers_NFLPlayerId",
                        column: x => x.NFLPlayerId,
                        principalSchema: "ff",
                        principalTable: "NFLPlayers",
                        principalColumn: "NFLPlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matchups",
                schema: "ff",
                columns: table => new
                {
                    MatchupId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Week = table.Column<byte>(type: "tinyint", nullable: false),
                    WinnerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Roster1Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Roster2Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SeasonId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchups", x => x.MatchupId);
                    table.ForeignKey(
                        name: "FK_Matchups_MatchupRosters_Roster1Id",
                        column: x => x.Roster1Id,
                        principalSchema: "ff",
                        principalTable: "MatchupRosters",
                        principalColumn: "RosterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matchups_MatchupRosters_Roster2Id",
                        column: x => x.Roster2Id,
                        principalSchema: "ff",
                        principalTable: "MatchupRosters",
                        principalColumn: "RosterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matchups_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalSchema: "ff",
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DraftedPlayers_NFLPlayerId",
                schema: "ff",
                table: "DraftedPlayers",
                column: "NFLPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftedPlayers_TeamId",
                schema: "ff",
                table: "DraftedPlayers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Drafts_SeasonId",
                schema: "ff",
                table: "Drafts",
                column: "SeasonId",
                unique: true,
                filter: "[SeasonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerSeasons_ManagerId",
                schema: "ff",
                table: "ManagerSeasons",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerSeasons_SeasonId",
                schema: "ff",
                table: "ManagerSeasons",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchupPlayers_NFLPlayerId",
                schema: "ff",
                table: "MatchupPlayers",
                column: "NFLPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchupPlayers_RosterId",
                schema: "ff",
                table: "MatchupPlayers",
                column: "RosterId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchupRosters_TeamId",
                schema: "ff",
                table: "MatchupRosters",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchups_Roster1Id",
                schema: "ff",
                table: "Matchups",
                column: "Roster1Id",
                unique: true,
                filter: "[Roster1Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Matchups_Roster2Id",
                schema: "ff",
                table: "Matchups",
                column: "Roster2Id",
                unique: true,
                filter: "[Roster2Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Matchups_SeasonId",
                schema: "ff",
                table: "Matchups",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_LeagueId",
                schema: "ff",
                table: "Seasons",
                column: "LeagueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DraftedPlayers",
                schema: "ff");

            migrationBuilder.DropTable(
                name: "Drafts",
                schema: "ff");

            migrationBuilder.DropTable(
                name: "EloScores",
                schema: "ff");

            migrationBuilder.DropTable(
                name: "MatchupPlayers",
                schema: "ff");

            migrationBuilder.DropTable(
                name: "Matchups",
                schema: "ff");

            migrationBuilder.DropTable(
                name: "NFLPlayers",
                schema: "ff");

            migrationBuilder.DropTable(
                name: "MatchupRosters",
                schema: "ff");

            migrationBuilder.DropTable(
                name: "ManagerSeasons",
                schema: "ff");

            migrationBuilder.DropTable(
                name: "Managers",
                schema: "ff");

            migrationBuilder.DropTable(
                name: "Seasons",
                schema: "ff");

            migrationBuilder.DropTable(
                name: "Leagues",
                schema: "ff");
        }
    }
}
