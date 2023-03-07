using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyRepo.SQL.Migrations
{
    public partial class Update_Positions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DraftedPlayers_ManagerSeasons_TeamId",
                schema: "ff",
                table: "DraftedPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_Drafts_Seasons_SeasonId",
                schema: "ff",
                table: "Drafts");

            migrationBuilder.DropForeignKey(
                name: "FK_ManagerSeasons_Managers_ManagerId",
                schema: "ff",
                table: "ManagerSeasons");

            migrationBuilder.DropForeignKey(
                name: "FK_ManagerSeasons_Seasons_SeasonId",
                schema: "ff",
                table: "ManagerSeasons");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchupRosters_ManagerSeasons_TeamId",
                schema: "ff",
                table: "MatchupRosters");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Seasons_YahooLeagueId",
                schema: "ff",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Drafts_SeasonId",
                schema: "ff",
                table: "Drafts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManagerSeasons",
                schema: "ff",
                table: "ManagerSeasons");

            migrationBuilder.DropColumn(
                name: "YahooLeagueId",
                schema: "ff",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "YahooId",
                schema: "ff",
                table: "NFLPlayers");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                schema: "ff",
                table: "Drafts");

            migrationBuilder.RenameTable(
                name: "ManagerSeasons",
                schema: "ff",
                newName: "Team",
                newSchema: "ff");

            migrationBuilder.RenameColumn(
                name: "NFLPosition",
                schema: "ff",
                table: "NFLPlayers",
                newName: "PrimaryPosition");

            migrationBuilder.RenameIndex(
                name: "IX_ManagerSeasons_SeasonId",
                schema: "ff",
                table: "Team",
                newName: "IX_Team_SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_ManagerSeasons_ManagerId",
                schema: "ff",
                table: "Team",
                newName: "IX_Team_ManagerId");

            migrationBuilder.AddColumn<string>(
                name: "DraftId",
                schema: "ff",
                table: "Seasons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayPosition",
                schema: "ff",
                table: "NFLPlayers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EligiblePositions",
                schema: "ff",
                table: "MatchupPlayers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DraftId",
                schema: "ff",
                table: "DraftedPlayers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "LossesDivision",
                schema: "ff",
                table: "Team",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "PlayoffSeed",
                schema: "ff",
                table: "Team",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "TiesDivision",
                schema: "ff",
                table: "Team",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "WinsDivision",
                schema: "ff",
                table: "Team",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                schema: "ff",
                table: "Team",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_DraftId",
                schema: "ff",
                table: "Seasons",
                column: "DraftId",
                unique: true,
                filter: "[DraftId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DraftedPlayers_DraftId",
                schema: "ff",
                table: "DraftedPlayers",
                column: "DraftId");

            migrationBuilder.AddForeignKey(
                name: "FK_DraftedPlayers_Drafts_DraftId",
                schema: "ff",
                table: "DraftedPlayers",
                column: "DraftId",
                principalSchema: "ff",
                principalTable: "Drafts",
                principalColumn: "DraftId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DraftedPlayers_Team_TeamId",
                schema: "ff",
                table: "DraftedPlayers",
                column: "TeamId",
                principalSchema: "ff",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchupRosters_Team_TeamId",
                schema: "ff",
                table: "MatchupRosters",
                column: "TeamId",
                principalSchema: "ff",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Drafts_DraftId",
                schema: "ff",
                table: "Seasons",
                column: "DraftId",
                principalSchema: "ff",
                principalTable: "Drafts",
                principalColumn: "DraftId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Managers_ManagerId",
                schema: "ff",
                table: "Team",
                column: "ManagerId",
                principalSchema: "ff",
                principalTable: "Managers",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Seasons_SeasonId",
                schema: "ff",
                table: "Team",
                column: "SeasonId",
                principalSchema: "ff",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DraftedPlayers_Drafts_DraftId",
                schema: "ff",
                table: "DraftedPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_DraftedPlayers_Team_TeamId",
                schema: "ff",
                table: "DraftedPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchupRosters_Team_TeamId",
                schema: "ff",
                table: "MatchupRosters");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Drafts_DraftId",
                schema: "ff",
                table: "Seasons");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Managers_ManagerId",
                schema: "ff",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Seasons_SeasonId",
                schema: "ff",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_DraftId",
                schema: "ff",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_DraftedPlayers_DraftId",
                schema: "ff",
                table: "DraftedPlayers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                schema: "ff",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "DraftId",
                schema: "ff",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "DisplayPosition",
                schema: "ff",
                table: "NFLPlayers");

            migrationBuilder.DropColumn(
                name: "EligiblePositions",
                schema: "ff",
                table: "MatchupPlayers");

            migrationBuilder.DropColumn(
                name: "DraftId",
                schema: "ff",
                table: "DraftedPlayers");

            migrationBuilder.DropColumn(
                name: "LossesDivision",
                schema: "ff",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "PlayoffSeed",
                schema: "ff",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "TiesDivision",
                schema: "ff",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "WinsDivision",
                schema: "ff",
                table: "Team");

            migrationBuilder.RenameTable(
                name: "Team",
                schema: "ff",
                newName: "ManagerSeasons",
                newSchema: "ff");

            migrationBuilder.RenameColumn(
                name: "PrimaryPosition",
                schema: "ff",
                table: "NFLPlayers",
                newName: "NFLPosition");

            migrationBuilder.RenameIndex(
                name: "IX_Team_SeasonId",
                schema: "ff",
                table: "ManagerSeasons",
                newName: "IX_ManagerSeasons_SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Team_ManagerId",
                schema: "ff",
                table: "ManagerSeasons",
                newName: "IX_ManagerSeasons_ManagerId");

            migrationBuilder.AddColumn<int>(
                name: "YahooLeagueId",
                schema: "ff",
                table: "Seasons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YahooId",
                schema: "ff",
                table: "NFLPlayers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeasonId",
                schema: "ff",
                table: "Drafts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Seasons_YahooLeagueId",
                schema: "ff",
                table: "Seasons",
                column: "YahooLeagueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManagerSeasons",
                schema: "ff",
                table: "ManagerSeasons",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Drafts_SeasonId",
                schema: "ff",
                table: "Drafts",
                column: "SeasonId",
                unique: true,
                filter: "[SeasonId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DraftedPlayers_ManagerSeasons_TeamId",
                schema: "ff",
                table: "DraftedPlayers",
                column: "TeamId",
                principalSchema: "ff",
                principalTable: "ManagerSeasons",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Drafts_Seasons_SeasonId",
                schema: "ff",
                table: "Drafts",
                column: "SeasonId",
                principalSchema: "ff",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ManagerSeasons_Managers_ManagerId",
                schema: "ff",
                table: "ManagerSeasons",
                column: "ManagerId",
                principalSchema: "ff",
                principalTable: "Managers",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ManagerSeasons_Seasons_SeasonId",
                schema: "ff",
                table: "ManagerSeasons",
                column: "SeasonId",
                principalSchema: "ff",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchupRosters_ManagerSeasons_TeamId",
                schema: "ff",
                table: "MatchupRosters",
                column: "TeamId",
                principalSchema: "ff",
                principalTable: "ManagerSeasons",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
