using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;
using System;

namespace ijlynivfhp.WEBService.SeckillServices.Migrations
{
    public partial class seckills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeckillRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Createtime = table.Column<DateTime>(nullable: false),
                    Updatetime = table.Column<DateTime>(nullable: false),
                    RecordTotalprice = table.Column<decimal>(nullable: false),
                    SeckillId = table.Column<int>(nullable: false),
                    SeckillNum = table.Column<int>(nullable: false),
                    SeckillPrice = table.Column<decimal>(nullable: false),
                    ProductPrice = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    RecordStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeckillRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seckills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SeckillType = table.Column<int>(nullable: false),
                    SeckillName = table.Column<string>(nullable: true),
                    SeckillUrl = table.Column<string>(nullable: true),
                    SeckillPrice = table.Column<decimal>(nullable: false),
                    SeckillStock = table.Column<int>(nullable: false),
                    SeckillSum = table.Column<int>(nullable: false),
                    SeckillPercent = table.Column<string>(nullable: true),
                    TimeId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    SeckillLimit = table.Column<int>(nullable: false),
                    SeckillDescription = table.Column<string>(nullable: true),
                    SeckillIstop = table.Column<int>(nullable: false),
                    SeckillStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seckills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeckillTimeModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TimeTitleUrl = table.Column<string>(nullable: true),
                    SeckillDate = table.Column<DateTime>(nullable: false),
                    SeckillStarttime = table.Column<int>(nullable: false),
                    SeckillEndtime = table.Column<int>(nullable: false),
                    TimeStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeckillTimeModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeckillRecords");

            migrationBuilder.DropTable(
                name: "Seckills");

            migrationBuilder.DropTable(
                name: "SeckillTimeModels");
        }
    }
}
