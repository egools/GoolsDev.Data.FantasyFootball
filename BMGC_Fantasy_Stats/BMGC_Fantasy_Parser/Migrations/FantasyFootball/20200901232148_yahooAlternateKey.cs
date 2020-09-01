using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyParser.Migrations.FantasyFootball
{
    public partial class yahooAlternateKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManagerSeasons_Managers_ManagerId",
                table: "ManagerSeasons");

            migrationBuilder.AlterColumn<int>(
                name: "YahooLeagueId",
                table: "Seasons",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ManagerId",
                table: "ManagerSeasons",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Seasons_YahooLeagueId",
                table: "Seasons",
                column: "YahooLeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManagerSeasons_Managers_ManagerId",
                table: "ManagerSeasons",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManagerSeasons_Managers_ManagerId",
                table: "ManagerSeasons");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Seasons_YahooLeagueId",
                table: "Seasons");

            migrationBuilder.AlterColumn<int>(
                name: "YahooLeagueId",
                table: "Seasons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<Guid>(
                name: "ManagerId",
                table: "ManagerSeasons",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_ManagerSeasons_Managers_ManagerId",
                table: "ManagerSeasons",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
