using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesLibraryAPI.Migrations
{
    public partial class redesignnewtable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGamesPlatforms",
                table: "UserGamesPlatforms",
                columns: new[] { "GameId", "PlatformId", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGamesPlatforms",
                table: "UserGamesPlatforms");
        }
    }
}
