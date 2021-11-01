using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ijlynivfhp.Core.WEBService.OrderServices.Migrations
{
    public partial class orders3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    OrderSn = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    ProductUrl = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    ItemPrice = table.Column<decimal>(nullable: false),
                    ItemCount = table.Column<int>(nullable: false),
                    ItemTotalPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");
        }
    }
}
