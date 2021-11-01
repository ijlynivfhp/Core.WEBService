using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;
using System;

namespace ijlynivfhp.WEBService.PaymentServices.Migrations
{
    public partial class payments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PaymentPrice = table.Column<string>(nullable: true),
                    PaymentStatus = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    PaymentType = table.Column<string>(nullable: true),
                    PaymentMethod = table.Column<string>(nullable: true),
                    Createtime = table.Column<DateTime>(nullable: false),
                    Updatetime = table.Column<DateTime>(nullable: false),
                    PaymentRemark = table.Column<string>(nullable: true),
                    PaymentUrl = table.Column<string>(nullable: true),
                    PaymentReturnUrl = table.Column<string>(nullable: true),
                    PaymentCode = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    PaymentErrorNo = table.Column<string>(nullable: true),
                    PaymentErrorInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
