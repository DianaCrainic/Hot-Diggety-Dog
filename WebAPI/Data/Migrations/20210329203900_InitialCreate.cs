using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class InitialCreate : Migration
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("0be0c246-1d73-4356-9413-89bade5a6fdd"), "Grimmer's Road" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("a43a05b4-5824-4193-8f73-d78f1d1ffee4"), "Fieldfare Banks" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("272014eb-b075-4ff0-bc55-683a3c2d4e42"), "Imperial Passage" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("09f193ae-1f0b-42bf-a1c6-18682cb209be"), "Woodville Square" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("90253414-0f00-4305-99d1-644fa9f8743c"), "Lindsey Circle" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("6e2a8244-5570-4843-8de3-e23573db3cfe"), "Alexander Banks" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("4a8a4b18-a729-4b8f-aa6c-36b097be6f16"), "HotDogs", "Basic hot dog with ketchup/mustard", "Hot Dog", 10f });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("dbcb31c7-e31e-40b2-aa30-c4eb1fc29b0a"), "HotDogs", "Hot dog with caramelized onions and ketchup", "Hot Onion Dog", 12.5f });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("6ea3ff43-ea57-4a55-ac2a-5f0a692a6716"), "HotDogs", "Hot dog with melted gouda cheese and bacon", "Bacon Melt", 15f });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("5131aa05-a77c-4e4f-a2ef-1acffb080c14"), "Extras", "Regular fries", "Fries", 7.5f });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("1ed725f5-630a-4b12-85dc-5735bcb5a60b"), "Drinks", "Cola bottle", "Coke", 5f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotDogStands");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
