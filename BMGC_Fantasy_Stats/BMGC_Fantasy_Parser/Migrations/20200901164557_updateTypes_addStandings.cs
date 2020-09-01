using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyParser.Migrations
{
    public partial class updateTypes_addStandings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Year",
                table: "Seasons",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Week",
                table: "Matchups",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ProjectedScore",
                table: "MatchupRosters",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "ActualScore",
                table: "MatchupRosters",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<short>(
                name: "TradesMade",
                table: "ManagerSeasons",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "MovesMade",
                table: "ManagerSeasons",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<short>(
                name: "FinalRank",
                table: "ManagerSeasons",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Losses",
                table: "ManagerSeasons",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "RegularSeasonRank",
                table: "ManagerSeasons",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Ties",
                table: "ManagerSeasons",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Wins",
                table: "ManagerSeasons",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<short>(
                name: "YearJoined",
                table: "Managers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Year",
                table: "EloScores",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Week",
                table: "EloScores",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ProjectedModifier",
                table: "EloScores",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<short>(
                name: "PreviousRatingAdjusted",
                table: "EloScores",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "PreviousRating",
                table: "EloScores",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "MarginModifier",
                table: "EloScores",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<short>(
                name: "ChangeAdjusted",
                table: "EloScores",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "Change",
                table: "EloScores",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "Budget",
                table: "Drafts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Round",
                table: "DraftedPlayers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Price",
                table: "DraftedPlayers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "DraftPosition",
                table: "DraftedPlayers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalRank",
                table: "ManagerSeasons");

            migrationBuilder.DropColumn(
                name: "Losses",
                table: "ManagerSeasons");

            migrationBuilder.DropColumn(
                name: "RegularSeasonRank",
                table: "ManagerSeasons");

            migrationBuilder.DropColumn(
                name: "Ties",
                table: "ManagerSeasons");

            migrationBuilder.DropColumn(
                name: "Wins",
                table: "ManagerSeasons");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Seasons",
                type: "int",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "Week",
                table: "Matchups",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<double>(
                name: "ProjectedScore",
                table: "MatchupRosters",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<double>(
                name: "ActualScore",
                table: "MatchupRosters",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "TradesMade",
                table: "ManagerSeasons",
                type: "int",
                nullable: true,
                oldClrType: typeof(short),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovesMade",
                table: "ManagerSeasons",
                type: "int",
                nullable: true,
                oldClrType: typeof(short),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "YearJoined",
                table: "Managers",
                type: "int",
                nullable: true,
                oldClrType: typeof(short),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "EloScores",
                type: "int",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "Week",
                table: "EloScores",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<double>(
                name: "ProjectedModifier",
                table: "EloScores",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "PreviousRatingAdjusted",
                table: "EloScores",
                type: "int",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "PreviousRating",
                table: "EloScores",
                type: "int",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<double>(
                name: "MarginModifier",
                table: "EloScores",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "ChangeAdjusted",
                table: "EloScores",
                type: "int",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "Change",
                table: "EloScores",
                type: "int",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "Budget",
                table: "Drafts",
                type: "int",
                nullable: true,
                oldClrType: typeof(short),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Round",
                table: "DraftedPlayers",
                type: "int",
                nullable: true,
                oldClrType: typeof(short),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "DraftedPlayers",
                type: "int",
                nullable: true,
                oldClrType: typeof(short),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DraftPosition",
                table: "DraftedPlayers",
                type: "int",
                nullable: true,
                oldClrType: typeof(short),
                oldNullable: true);
        }
    }
}
