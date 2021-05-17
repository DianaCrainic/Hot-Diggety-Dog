using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "InventoryProducts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    product_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryProducts", x => x.id);
                    table.ForeignKey(
                        name: "FK_InventoryProducts_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotDogStands",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    address = table.Column<string>(type: "TEXT", nullable: false),
                    OperatorId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotDogStands", x => x.id);
                    table.ForeignKey(
                        name: "FK_HotDogStands_Users_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "HotDogStandProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StandId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotDogStandProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotDogStandProduct_HotDogStands_StandId",
                        column: x => x.StandId,
                        principalTable: "HotDogStands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotDogStandProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
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
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("34ab4a2a-8c69-4298-9a44-c868ee47375b"), "HotDogs", "Basic hot dog with ketchup/mustard", "Hot Dog", 10f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("92743ec9-aec8-4a72-8b91-f0a61d28f6c4"), "HotDogs", "Hot dog with caramelized onions and ketchup", "Hot Onion Dog", 12.5f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("fe7b2b0f-26b0-424c-bf7f-ccd875bc5c18"), "HotDogs", "Hot dog with melted gouda cheese and bacon", "Bacon Melt", 15f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("958dc136-e4b9-4be3-a2f2-3f8a1b92bceb"), "Extras", "Regular fries", "Fries", 7.5f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("3c918fbd-8262-404c-983e-0b9987fc5eec"), "Drinks", "Coke bottle", "Coke", 5f });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("ee64e669-9268-4a6b-b39d-7617bdaae89c"), "customer@gmail.com", "B6C45863875E34487CA3C155ED145EFE12A74581E27BEFEC5AA661B8EE8CA6DD", 0, "customer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("2dc1f841-4afa-46ac-aaaf-93699fa7e2f6"), "admin@gmail.com", "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918", 3, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("9fa4bd49-474d-4de0-9ed2-db9c358ed862"), "supplier@gmail.com", "955ED10B73D6265B1ADCF768B94F8DD5D91F33309DB94B6B3AF4EFA822F1D9AF", 2, "supplier" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("afb6fe28-3d7e-4498-9472-131229b4ba36"), "operator1@gmail.com", "941E65AF88E0945C9F7DB5C306B0EF0FC5763DF6BFC9D339FF235195885083A2", 1, "operator1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("40f70218-632b-4130-8254-4137ff4ed57d"), "operator2@gmail.com", "6EED3508EEE654F48CC4D57910EAD9310E4B2B386248D56BD40BBF16FCD9A77F", 1, "operator2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("4e1bea32-296d-49b0-a63d-98e592d44fdc"), "operator3@gmail.com", "0A722A639AB7D77124CDD29A0AD96FF421D50DC97A079705C4D5B2D97CF347B0", 1, "operator3" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("4b5eaa24-d8bd-492c-90b1-84c26c1ba885"), "operator4@gmail.com", "D71C5645CC3D232BCBD657888C4FF6AC0C6E33E2B89FB2162F8D96F276E8623A", 1, "operator4" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address", "OperatorId" },
                values: new object[] { new Guid("a63a5198-b139-490e-81bf-18dac00a8700"), "Grimmer's Road", new Guid("afb6fe28-3d7e-4498-9472-131229b4ba36") });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address", "OperatorId" },
                values: new object[] { new Guid("aca46489-167a-404f-93f9-0fc97358961d"), "Fieldfare Banks", new Guid("40f70218-632b-4130-8254-4137ff4ed57d") });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address", "OperatorId" },
                values: new object[] { new Guid("ae9e8c60-bfbd-486f-9a3d-c98da3bcbec9"), "Imperial Passage", new Guid("4e1bea32-296d-49b0-a63d-98e592d44fdc") });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address", "OperatorId" },
                values: new object[] { new Guid("10515d8f-50a9-4e06-8dd2-8c6dcc3548e4"), "Woodville Square", new Guid("4b5eaa24-d8bd-492c-90b1-84c26c1ba885") });

            migrationBuilder.InsertData(
                table: "HotDogStandProduct",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("5d7255f2-a66e-484c-8ccf-dbf4d8e5055b"), new Guid("34ab4a2a-8c69-4298-9a44-c868ee47375b"), 7, new Guid("a63a5198-b139-490e-81bf-18dac00a8700") });

            migrationBuilder.InsertData(
                table: "HotDogStandProduct",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("59306bb2-6f55-4647-8fe3-996313af8b16"), new Guid("92743ec9-aec8-4a72-8b91-f0a61d28f6c4"), 10, new Guid("a63a5198-b139-490e-81bf-18dac00a8700") });

            migrationBuilder.InsertData(
                table: "HotDogStandProduct",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("fc9b7d9d-ec19-46f7-8490-38fa205cc0b9"), new Guid("fe7b2b0f-26b0-424c-bf7f-ccd875bc5c18"), 13, new Guid("a63a5198-b139-490e-81bf-18dac00a8700") });

            migrationBuilder.InsertData(
                table: "HotDogStandProduct",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("f5917d65-f51a-4910-ba61-59b81d5b99e8"), new Guid("34ab4a2a-8c69-4298-9a44-c868ee47375b"), 20, new Guid("aca46489-167a-404f-93f9-0fc97358961d") });

            migrationBuilder.InsertData(
                table: "HotDogStandProduct",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("afd9cfc1-7e1c-47d0-a095-757f4b2fbef1"), new Guid("92743ec9-aec8-4a72-8b91-f0a61d28f6c4"), 6, new Guid("aca46489-167a-404f-93f9-0fc97358961d") });

            migrationBuilder.CreateIndex(
                name: "IX_HotDogStandProduct_ProductId",
                table: "HotDogStandProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_HotDogStandProduct_StandId",
                table: "HotDogStandProduct",
                column: "StandId");

            migrationBuilder.CreateIndex(
                name: "IX_HotDogStands_OperatorId",
                table: "HotDogStands",
                column: "OperatorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryProducts_product_id",
                table: "InventoryProducts",
                column: "product_id");

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
                name: "HotDogStandProduct");

            migrationBuilder.DropTable(
                name: "InventoryProducts");

            migrationBuilder.DropTable(
                name: "OrdersProducts");

            migrationBuilder.DropTable(
                name: "HotDogStands");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
