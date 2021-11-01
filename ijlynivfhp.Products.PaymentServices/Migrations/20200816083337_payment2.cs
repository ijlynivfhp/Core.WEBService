using Microsoft.EntityFrameworkCore.Migrations;

namespace ijlynivfhp.WEBService.PaymentServices.Migrations
{
    public partial class payment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PaymentType",
                table: "Payments",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PaymentType",
                table: "Payments",
                type: "text",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
