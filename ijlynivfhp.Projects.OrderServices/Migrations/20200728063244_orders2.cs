using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ijlynivfhp.Projects.OrderServices.Migrations
{
    public partial class orders2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Createtime",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OrderAddress",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderFlag",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderName",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderRemark",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderSn",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OrderTel",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderTotalPrice",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderType",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Paytime",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Sendtime",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Successtime",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updatetime",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Createtime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderFlag",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderRemark",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderSn",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderTel",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderTotalPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderType",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Paytime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Sendtime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Successtime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Updatetime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");
        }
    }
}
