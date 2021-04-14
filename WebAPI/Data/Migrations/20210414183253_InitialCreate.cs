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
                name: "Products",
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
                    table.PrimaryKey("PK_Products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    role = table.Column<int>(type: "INTEGER", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    timesptamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    total = table.Column<double>(type: "REAL", nullable: false),
                    operator_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    user_id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_operator_id",
                        column: x => x.operator_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersProducts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    order_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    product_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersProducts", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Orders_order_id",
                        column: x => x.order_id,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("98bcf46b-b4a4-45aa-82e5-1392735d0fd3"), "Grimmer's Road" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("05516f39-3af7-4501-a70d-2cb2f44bdc04"), "Fieldfare Banks" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("f375b413-e6ec-4d8c-9f7b-b746d6f8eb15"), "Imperial Passage" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("dfffff3c-fd96-49c4-a0b3-15b8388a6238"), "Woodville Square" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("fdfff333-c17c-48d2-a062-c60b32a92859"), "Lindsey Circle" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("2a4d47c5-7b2e-4fb0-b5ed-27d4d44965cd"), "Alexander Banks" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("6579d884-a57e-4553-99fe-993e2046d053"), "HotDogs", "Basic hot dog with ketchup/mustard", "Hot Dog", 10f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("e51f66a1-c146-4ec5-aa0e-1011ca01a21a"), "HotDogs", "Hot dog with caramelized onions and ketchup", "Hot Onion Dog", 12.5f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("5595ee76-a8ab-42cf-ba23-7a2909cac346"), "HotDogs", "Hot dog with melted gouda cheese and bacon", "Bacon Melt", 15f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("06acbfb7-ba4d-470b-9ae4-1fde0c73e9e3"), "Extras", "Regular fries", "Fries", 7.5f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("665da8b1-ea15-4aa0-9192-bca63e8d94fa"), "Drinks", "Coke bottle", "Coke", 5f });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("4241338f-82cf-4608-9eaa-48859efd14ba"), "customer@gmail.com", "B6C45863875E34487CA3C155ED145EFE12A74581E27BEFEC5AA661B8EE8CA6DD", 0, "customer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("2aa2b8db-43cc-46e4-b604-6016e6476920"), "admin@gmail.com", "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918", 3, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("5dbb6448-4628-489b-8798-60279aaf03b2"), "operator@gmail.com", "06E55B633481F7BB072957EABCF110C972E86691C3CFEDABE088024BFFE42F23", 1, "operator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("c4cf24ca-2cf7-4924-b740-094a29db504e"), "supplier@gmail.com", "955ED10B73D6265B1ADCF768B94F8DD5D91F33309DB94B6B3AF4EFA822F1D9AF", 2, "supplier" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_operator_id",
                table: "Orders",
                column: "operator_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_user_id",
                table: "Orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_order_id",
                table: "OrdersProducts",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_product_id",
                table: "OrdersProducts",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotDogStands");

            migrationBuilder.DropTable(
                name: "OrdersProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
