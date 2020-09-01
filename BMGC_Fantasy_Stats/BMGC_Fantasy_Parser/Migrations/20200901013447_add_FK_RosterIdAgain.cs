using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyParser.Migrations
{
    public partial class add_FK_RosterIdAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchupPlayers_MatchupRosters_MatchupPlayerId",
                table: "MatchupPlayers");

            migrationBuilder.CreateIndex(
                name: "IX_MatchupPlayers_RosterId",
                table: "MatchupPlayers",
                column: "RosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchupPlayers_MatchupRosters_RosterId",
                table: "MatchupPlayers",
                column: "RosterId",
                principalTable: "MatchupRosters",
                principalColumn: "RosterId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchupPlayers_MatchupRosters_RosterId",
                table: "MatchupPlayers");

            migrationBuilder.DropIndex(
                name: "IX_MatchupPlayers_RosterId",
                table: "MatchupPlayers");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchupPlayers_MatchupRosters_MatchupPlayerId",
                table: "MatchupPlayers",
                column: "MatchupPlayerId",
                principalTable: "MatchupRosters",
                principalColumn: "RosterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
