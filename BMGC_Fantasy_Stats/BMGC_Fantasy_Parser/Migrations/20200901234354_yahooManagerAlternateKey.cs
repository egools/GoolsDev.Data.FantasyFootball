using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyParser.Migrations
{
    public partial class yahooManagerAlternateKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YahooManagerId",
                table: "Managers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Managers_YahooManagerId",
                table: "Managers",
                column: "YahooManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Managers_YahooManagerId",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "YahooManagerId",
                table: "Managers");
        }
    }
}
