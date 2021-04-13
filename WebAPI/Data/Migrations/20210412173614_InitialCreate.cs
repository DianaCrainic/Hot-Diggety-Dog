using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
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
                values: new object[] { new Guid("d45045d7-0d2c-44b0-97f5-f1b11ed98dff"), "Grimmer's Road" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("6e4f7be7-1b8f-4d85-9498-f4eae295f451"), "Fieldfare Banks" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("2124d56f-e724-4d5a-a873-d06945af2336"), "Imperial Passage" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("573fff02-9a30-4d57-b2e1-6bb9ce89b1a6"), "Woodville Square" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("18b5105a-bd83-43b0-867b-112be45b4e30"), "Lindsey Circle" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("eae26977-6799-440e-8088-e8cf1e54abe5"), "Alexander Banks" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("99fca172-ce7a-40b4-870c-febb3d23c0c0"), "HotDogs", "Basic hot dog with ketchup/mustard", "Hot Dog", 10f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("5b4d64d9-b150-47bb-b852-a34e5b6a1bf6"), "HotDogs", "Hot dog with caramelized onions and ketchup", "Hot Onion Dog", 12.5f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("c94e970e-4804-4bec-aeee-184c15450fbf"), "HotDogs", "Hot dog with melted gouda cheese and bacon", "Bacon Melt", 15f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("973a2600-e3d1-4c7e-ab49-247fcfe99e09"), "Extras", "Regular fries", "Fries", 7.5f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("7a16889a-3309-4471-b37d-a9098048c8d3"), "Drinks", "Coke bottle", "Coke", 5f });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("5aabb1a0-b316-4281-9e28-fc5a0a7947cd"), "customer@gmail.com", "B6C45863875E34487CA3C155ED145EFE12A74581E27BEFEC5AA661B8EE8CA6DD", 0, "customer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("1dc9fd95-b148-4ec3-b765-2e5eb4881094"), "admin@gmail.com", "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918", 3, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("5a9151ba-16f3-4f5f-8ac1-1f39d6ab357b"), "operator@gmail.com", "06E55B633481F7BB072957EABCF110C972E86691C3CFEDABE088024BFFE42F23", 1, "operator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("b60f2f68-612a-4607-9174-e0735d594d40"), "supplier@gmail.com", "955ED10B73D6265B1ADCF768B94F8DD5D91F33309DB94B6B3AF4EFA822F1D9AF", 2, "supplier" });

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
