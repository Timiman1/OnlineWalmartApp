using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineWalmart.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    DeliveryInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DeliveryInfo", "Description", "Discount", "Name", "Price" },
                values: new object[] { new Guid("3de11058-7854-4473-9404-17bfeb480af5"), "Come and pick up in our store within 14 days.", "Very ecological and efficient", 0.0, "Jumprope", 12.15 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DeliveryInfo", "Description", "Discount", "Name", "Price" },
                values: new object[] { new Guid("569a37e6-4bef-4619-bafc-48533e9c86a5"), "Delivery with Instabox within 0-2 working days", "Cedar wood", 0.0, "Wooden Spatula", 14.35 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
