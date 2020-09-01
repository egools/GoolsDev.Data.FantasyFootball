using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyParser.Migrations
{
    public partial class add_FK_MatchupPlayerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchupPlayers_MatchupRosters_MatchupPlayerID",
                table: "MatchupPlayers");

            migrationBuilder.RenameColumn(
                name: "MatchupPlayerID",
                table: "MatchupPlayers",
                newName: "MatchupPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchupPlayers_MatchupRosters_MatchupPlayerId",
                table: "MatchupPlayers",
                column: "MatchupPlayerId",
                principalTable: "MatchupRosters",
                principalColumn: "RosterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchupPlayers_MatchupRosters_MatchupPlayerId",
                table: "MatchupPlayers");

            migrationBuilder.RenameColumn(
                name: "MatchupPlayerId",
                table: "MatchupPlayers",
                newName: "MatchupPlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchupPlayers_MatchupRosters_MatchupPlayerID",
                table: "MatchupPlayers",
                column: "MatchupPlayerID",
                principalTable: "MatchupRosters",
                principalColumn: "RosterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
