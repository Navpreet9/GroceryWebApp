using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroceryWebApp.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryCode = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Groceries",
                columns: table => new
                {
                    GroceryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroceryName = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    BrandID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groceries", x => x.GroceryID);
                    table.ForeignKey(
                        name: "FK_Groceries_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groceries_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroceryID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Groceries_GroceryID",
                        column: x => x.GroceryID,
                        principalTable: "Groceries",
                        principalColumn: "GroceryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_BrandID",
                table: "Groceries",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_CategoryID",
                table: "Groceries",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_GroceryID",
                table: "Orders",
                column: "GroceryID");
            var sqlFile = Path.Combine(".\\Data", @"data.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Groceries");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
