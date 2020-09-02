using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyParser.Migrations.FantasyFootball
{
    public partial class addYearToManagerSeason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Year",
                table: "ManagerSeasons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "ManagerSeasons");
        }
    }
}
