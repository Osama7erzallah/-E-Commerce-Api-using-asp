using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalUserId = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_LocalUsers_LocalUserId",
                        column: x => x.LocalUserId,
                        principalTable: "LocalUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetiles", x => new { x.Id, x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderDetiles_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetiles_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "description" },
                values: new object[,]
                {
                    { 1, "Electronics", "Devices and gadgets" },
                    { 2, "Books", "Books and literature" },
                    { 3, "Clothing", "Apparel and accessories" },
                    { 4, "Home Appliances", "Household items and appliances" },
                    { 5, "Toys", "Toys and games for children" }
                });

            migrationBuilder.InsertData(
                table: "LocalUsers",
                columns: new[] { "Id", "Email", "Name", "Password", "Phone", "Role" },
                values: new object[,]
                {
                    { 1, "ahmed@example.com", "Ahmed Haggag", "password123", "1234567890", "Admin" },
                    { 2, "tarek@example.com", "Tarek Sharim", "password456", "0987654321", "User" },
                    { 3, "sara@example.com", "Sara Ali", "password789", "1122334455", "User" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "LocalUserId", "OrderDate", "OrderStatus" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 2, 2, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 3, 1, new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipped" },
                    { 4, 3, new DateTime(2023, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 5, 3, new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price", "image" },
                values: new object[,]
                {
                    { 1, 1, "Smartphone", 299.99m, "smartphone.jpg" },
                    { 2, 1, "Laptop", 799.99m, "laptop.jpg" },
                    { 3, 2, "Novel", 19.99m, "novel.jpg" },
                    { 4, 3, "T-Shirt", 9.99m, "tshirt.jpg" },
                    { 5, 3, "Jeans", 49.99m, "jeans.jpg" },
                    { 6, 4, "Washing Machine", 499.99m, "washing_machine.jpg" },
                    { 7, 4, "Microwave", 99.99m, "microwave.jpg" },
                    { 8, 5, "Teddy Bear", 14.99m, "teddy_bear.jpg" },
                    { 9, 5, "Toy Car", 9.99m, "toy_car.jpg" }
                });

            migrationBuilder.InsertData(
                table: "OrderDetiles",
                columns: new[] { "Id", "OrderId", "ProductId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 299.99m, 1m },
                    { 2, 1, 4, 9.99m, 2m },
                    { 3, 2, 3, 19.99m, 1m },
                    { 4, 3, 2, 799.99m, 1m },
                    { 5, 3, 5, 49.99m, 1m },
                    { 6, 4, 6, 499.99m, 1m },
                    { 7, 4, 8, 14.99m, 2m },
                    { 8, 5, 7, 99.99m, 1m },
                    { 9, 5, 9, 9.99m, 3m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetiles_OrderId",
                table: "OrderDetiles",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetiles_ProductId",
                table: "OrderDetiles",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LocalUserId",
                table: "Orders",
                column: "LocalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetiles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
