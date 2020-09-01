using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyParser.Migrations
{
    public partial class AddYahooLeagueId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YahooLeagueId",
                table: "Seasons",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YahooLeagueId",
                table: "Seasons");
        }
    }
}
