using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
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
                    address = table.Column<string>(type: "TEXT", nullable: false),
                    OperatorId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                columns: new[] { "id", "address", "OperatorId" },
                values: new object[] { new Guid("70f9917f-c66d-46a2-aa21-bfd9a4fe6c17"), "Grimmer's Road", new Guid("3622398d-c8ea-475d-800e-18c76c169939") });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address", "OperatorId" },
                values: new object[] { new Guid("ff213fc9-9545-49e4-8344-eade3591c1c4"), "Fieldfare Banks", new Guid("6bf1323f-4c28-4355-8440-258f796b78cb") });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address", "OperatorId" },
                values: new object[] { new Guid("4ff14256-a670-47d2-9410-d03b7c53654a"), "Imperial Passage", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address", "OperatorId" },
                values: new object[] { new Guid("be5fcf01-498c-4e77-b8e1-545c634fb417"), "Woodville Square", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address", "OperatorId" },
                values: new object[] { new Guid("461715be-00c9-4a47-be4a-c76b73668bb7"), "Lindsey Circle", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address", "OperatorId" },
                values: new object[] { new Guid("4858edf6-9d80-4f6b-8248-3bb849c61477"), "Alexander Banks", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("44d52564-876b-47d1-9580-c0afca617389"), "HotDogs", "Basic hot dog with ketchup/mustard", "Hot Dog", 10f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("7ae695fe-697e-46ad-8b8c-8f995ec08d19"), "HotDogs", "Hot dog with caramelized onions and ketchup", "Hot Onion Dog", 12.5f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("3424f816-446d-4bea-bc40-7ef0f785422f"), "HotDogs", "Hot dog with melted gouda cheese and bacon", "Bacon Melt", 15f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("9e6aaf35-34f4-4c94-8db6-e3578a931142"), "Extras", "Regular fries", "Fries", 7.5f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("e385ba99-4967-44ad-89dc-32dabb39422c"), "Drinks", "Coke bottle", "Coke", 5f });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("9fc728c9-9568-4649-817a-9d8060bde6bf"), "customer@gmail.com", "B6C45863875E34487CA3C155ED145EFE12A74581E27BEFEC5AA661B8EE8CA6DD", 0, "customer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("71cb42b6-5cde-4a04-abc7-60cbb9ac48fb"), "admin@gmail.com", "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918", 3, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("a9baaf62-38fb-44ca-8e08-0219bbf0a548"), "supplier@gmail.com", "955ED10B73D6265B1ADCF768B94F8DD5D91F33309DB94B6B3AF4EFA822F1D9AF", 2, "supplier" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("3622398d-c8ea-475d-800e-18c76c169939"), "operator1@gmail.com", "941E65AF88E0945C9F7DB5C306B0EF0FC5763DF6BFC9D339FF235195885083A2", 1, "operator1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("6bf1323f-4c28-4355-8440-258f796b78cb"), "operator2@gmail.com", "6EED3508EEE654F48CC4D57910EAD9310E4B2B386248D56BD40BBF16FCD9A77F", 1, "operator2" });

            migrationBuilder.InsertData(
                table: "HotDogStandProduct",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("8c32089d-9330-42d1-8fd1-0d9805c0976a"), new Guid("44d52564-876b-47d1-9580-c0afca617389"), 7, new Guid("70f9917f-c66d-46a2-aa21-bfd9a4fe6c17") });

            migrationBuilder.InsertData(
                table: "HotDogStandProduct",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("b3fdf0bb-91f7-4e73-966e-d0785e4bbe7e"), new Guid("44d52564-876b-47d1-9580-c0afca617389"), 20, new Guid("ff213fc9-9545-49e4-8344-eade3591c1c4") });

            migrationBuilder.InsertData(
                table: "HotDogStandProduct",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("6a260edd-129c-446a-81b5-8ca451a81274"), new Guid("7ae695fe-697e-46ad-8b8c-8f995ec08d19"), 10, new Guid("70f9917f-c66d-46a2-aa21-bfd9a4fe6c17") });

            migrationBuilder.InsertData(
                table: "HotDogStandProduct",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("93fee340-cff2-49ea-baf2-9f3674ae0a6b"), new Guid("7ae695fe-697e-46ad-8b8c-8f995ec08d19"), 6, new Guid("ff213fc9-9545-49e4-8344-eade3591c1c4") });

            migrationBuilder.InsertData(
                table: "HotDogStandProduct",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("dca638b3-f4b2-4cfa-b935-0ca72327c3b8"), new Guid("3424f816-446d-4bea-bc40-7ef0f785422f"), 13, new Guid("70f9917f-c66d-46a2-aa21-bfd9a4fe6c17") });

            migrationBuilder.CreateIndex(
                name: "IX_HotDogStandProduct_ProductId",
                table: "HotDogStandProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_HotDogStandProduct_StandId",
                table: "HotDogStandProduct",
                column: "StandId");

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
