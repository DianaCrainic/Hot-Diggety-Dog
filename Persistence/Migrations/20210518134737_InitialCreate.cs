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
                    quantity = table.Column<uint>(type: "INTEGER", nullable: false)
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
                    operator_id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotDogStands", x => x.id);
                    table.ForeignKey(
                        name: "FK_HotDogStands_Users_operator_id",
                        column: x => x.operator_id,
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
                name: "HotDogStandProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StandId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotDogStandProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotDogStandProducts_HotDogStands_StandId",
                        column: x => x.StandId,
                        principalTable: "HotDogStands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotDogStandProducts_Products_ProductId",
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
                values: new object[] { new Guid("6b08b544-fb5c-40fd-bd73-2b8fee034c3e"), "HotDogs", "Basic hot dog with ketchup/mustard", "Hot Dog", 10f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("4b27026c-98a1-4770-8de8-98a19150f3fd"), "HotDogs", "Hot dog with caramelized onions and ketchup", "Hot Onion Dog", 12.5f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("cc9ee8b8-472c-4da0-b263-98003389051b"), "HotDogs", "Hot dog with melted gouda cheese and bacon", "Bacon Melt", 15f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("b8956085-b852-40af-aeb7-9a39fa1c5cf9"), "Extras", "Regular fries", "Fries", 7.5f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("f8f7461c-6f43-4c6a-bab3-716c448b7be6"), "Drinks", "Coke bottle", "Coke", 5f });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("c7edd790-fa67-4ec1-b07f-21a0e2108a67"), "customer@gmail.com", "B6C45863875E34487CA3C155ED145EFE12A74581E27BEFEC5AA661B8EE8CA6DD", 0, "customer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("36bb81cc-918c-4798-812f-88b32f496556"), "admin@gmail.com", "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918", 3, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("afa2ab34-cdfd-4aea-bb39-f6d19a6af456"), "supplier@gmail.com", "955ED10B73D6265B1ADCF768B94F8DD5D91F33309DB94B6B3AF4EFA822F1D9AF", 2, "supplier" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("5e1115d2-f437-4f94-997b-2449cd849787"), "operator1@gmail.com", "941E65AF88E0945C9F7DB5C306B0EF0FC5763DF6BFC9D339FF235195885083A2", 1, "operator1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("81012b76-904b-4d96-bc95-3018cc0ba218"), "operator2@gmail.com", "6EED3508EEE654F48CC4D57910EAD9310E4B2B386248D56BD40BBF16FCD9A77F", 1, "operator2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("bcc2ae82-b3cc-445c-8644-9fdbfb107eac"), "operator3@gmail.com", "0A722A639AB7D77124CDD29A0AD96FF421D50DC97A079705C4D5B2D97CF347B0", 1, "operator3" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("fca8134c-74b8-4fd3-99ba-06a212ba1331"), "operator4@gmail.com", "D71C5645CC3D232BCBD657888C4FF6AC0C6E33E2B89FB2162F8D96F276E8623A", 1, "operator4" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address", "operator_id" },
                values: new object[] { new Guid("14e8dabb-9ffe-4646-85ae-aed53a52b50c"), "Grimmer's Road", new Guid("5e1115d2-f437-4f94-997b-2449cd849787") });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address", "operator_id" },
                values: new object[] { new Guid("af06b2ae-1a47-48c5-bbad-01dd9e78922a"), "Fieldfare Banks", new Guid("81012b76-904b-4d96-bc95-3018cc0ba218") });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address", "operator_id" },
                values: new object[] { new Guid("aaeb4067-ca4e-4c3d-976c-e5f8e06ba28c"), "Imperial Passage", new Guid("bcc2ae82-b3cc-445c-8644-9fdbfb107eac") });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address", "operator_id" },
                values: new object[] { new Guid("1d1baccd-d52b-4731-94f3-cde16c623e29"), "Woodville Square", new Guid("fca8134c-74b8-4fd3-99ba-06a212ba1331") });

            migrationBuilder.InsertData(
                table: "HotDogStandProducts",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("e757546a-f77f-44b9-aa6c-0ef6765aaf01"), new Guid("6b08b544-fb5c-40fd-bd73-2b8fee034c3e"), 7, new Guid("14e8dabb-9ffe-4646-85ae-aed53a52b50c") });

            migrationBuilder.InsertData(
                table: "HotDogStandProducts",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("da53b52d-21cf-4d3d-b570-0c0d310e0734"), new Guid("4b27026c-98a1-4770-8de8-98a19150f3fd"), 10, new Guid("14e8dabb-9ffe-4646-85ae-aed53a52b50c") });

            migrationBuilder.InsertData(
                table: "HotDogStandProducts",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("90feafa6-f623-4baa-be22-70b76744f9cd"), new Guid("cc9ee8b8-472c-4da0-b263-98003389051b"), 13, new Guid("14e8dabb-9ffe-4646-85ae-aed53a52b50c") });

            migrationBuilder.InsertData(
                table: "HotDogStandProducts",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("b4705633-1d21-4219-8639-a6784b4c1599"), new Guid("6b08b544-fb5c-40fd-bd73-2b8fee034c3e"), 20, new Guid("af06b2ae-1a47-48c5-bbad-01dd9e78922a") });

            migrationBuilder.InsertData(
                table: "HotDogStandProducts",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("8ce35291-004f-40f0-b81b-40e11af9c0d9"), new Guid("4b27026c-98a1-4770-8de8-98a19150f3fd"), 6, new Guid("af06b2ae-1a47-48c5-bbad-01dd9e78922a") });

            migrationBuilder.CreateIndex(
                name: "IX_HotDogStandProducts_ProductId",
                table: "HotDogStandProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_HotDogStandProducts_StandId",
                table: "HotDogStandProducts",
                column: "StandId");

            migrationBuilder.CreateIndex(
                name: "IX_HotDogStands_operator_id",
                table: "HotDogStands",
                column: "operator_id",
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
                name: "HotDogStandProducts");

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
