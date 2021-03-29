using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class StandsAndProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotDogStands",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotDogStands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    category = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("79865a99-7b94-4f85-8194-4ebf2d2bf48b"), "Strada Lalelelor" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("004bac14-b91b-412e-aca6-96b37812ec80"), "Strada Malinilor" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("a66f64e8-96af-4806-b458-22e9d382e458"), "Strada Copou" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("de8b3f2e-5361-4a59-967c-7aac813939a1"), "Strada Stramosilor" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("84a17198-7a72-4db1-b6a0-2fa1c5a0e7dc"), "Strada Brailei" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("a1051812-cc22-40a8-8bad-3230032e6fce"), "Sauce", "Ketchup for hot dogs", "Ketchup Tommy", 0f });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("d739001b-fe29-413c-8c11-3ed86c397dfd"), "Bread", "Bun for hot dog", "Happy Bunny", 0f });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("3fa1fb06-1c9a-4a43-b5aa-b6cadf528f6d"), "Meat", "Sausage for hot dogs", "Sausage", 0f });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("278aa4dc-a592-494e-b400-d67a2a6bdbd9"), "Sauce", "Mustard for hot dogs", "Golden Mustard", 0f });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("1f5df6eb-4d6a-4d17-8b71-80804c589406"), "Oils", "Oil for cooking", "Vinegar oil", 0f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotDogStands");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
