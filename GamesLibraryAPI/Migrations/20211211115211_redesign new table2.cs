using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesLibraryAPI.Migrations
{
    public partial class redesignnewtable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlatformName",
                table: "UserGamesPlatforms");

            migrationBuilder.AddColumn<int>(
                name: "PlatformId",
                table: "UserGamesPlatforms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "UserGamesPlatforms");

            migrationBuilder.AddColumn<string>(
                name: "PlatformName",
                table: "UserGamesPlatforms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
