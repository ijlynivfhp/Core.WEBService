using Microsoft.EntityFrameworkCore.Migrations;

namespace ijlynivfhp.Core.WEBService.SeckillServices.Migrations
{
    public partial class seckill3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeckillSum",
                table: "Seckills");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "SeckillRecords");

            migrationBuilder.AddColumn<string>(
                name: "OrderSn",
                table: "SeckillRecords",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderSn",
                table: "SeckillRecords");

            migrationBuilder.AddColumn<int>(
                name: "SeckillSum",
                table: "Seckills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "SeckillRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
