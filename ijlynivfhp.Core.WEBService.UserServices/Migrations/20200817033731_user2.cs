using Microsoft.EntityFrameworkCore.Migrations;

namespace ijlynivfhp.Core.WEBService.UserServices.Migrations
{
    public partial class user2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserQQ",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserQQ",
                table: "Users");
        }
    }
}
