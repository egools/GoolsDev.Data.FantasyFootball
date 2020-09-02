using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyParser.Migrations.FantasyFootball
{
    public partial class replaceMatchupWithMatchupId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchupRosters_Matchups_MatchupId",
                table: "MatchupRosters");

            migrationBuilder.DropIndex(
                name: "IX_MatchupRosters_MatchupId",
                table: "MatchupRosters");

            migrationBuilder.AlterColumn<Guid>(
                name: "MatchupId",
                table: "MatchupRosters",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "MatchupId",
                table: "MatchupRosters",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_MatchupRosters_MatchupId",
                table: "MatchupRosters",
                column: "MatchupId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchupRosters_Matchups_MatchupId",
                table: "MatchupRosters",
                column: "MatchupId",
                principalTable: "Matchups",
                principalColumn: "MatchupId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
