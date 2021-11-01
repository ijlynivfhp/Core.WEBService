using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ijlynivfhp.WEBService.SeckillServices.Migrations
{
    public partial class seckills2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SeckillStarttime",
                table: "SeckillTimeModels",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SeckillEndtime",
                table: "SeckillTimeModels",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SeckillDate",
                table: "SeckillTimeModels",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SeckillStarttime",
                table: "SeckillTimeModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SeckillEndtime",
                table: "SeckillTimeModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SeckillDate",
                table: "SeckillTimeModels",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
