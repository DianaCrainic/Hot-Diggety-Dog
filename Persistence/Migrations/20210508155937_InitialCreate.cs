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
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("12bd8fbf-967a-422d-b385-b47aba932514"), "Grimmer's Road" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("6dd91e54-82b9-4a6e-a4f4-076b0d8994d0"), "Fieldfare Banks" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("32e43d6a-bade-454d-8154-2a7bdb859644"), "Imperial Passage" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("42551a0a-6709-43e6-ad91-eceb6e19b844"), "Woodville Square" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("a59a3ee3-ab25-45ac-91e8-bad0b2c9d364"), "Lindsey Circle" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("0a8805cf-66e2-4b14-8ad9-9438cd713fc8"), "Alexander Banks" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("91627bef-b215-4fcb-a639-caba212daf71"), "HotDogs", "Basic hot dog with ketchup/mustard", "Hot Dog", 10f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("7c323cb5-ff68-48e5-9bee-33efeb01f85d"), "HotDogs", "Hot dog with caramelized onions and ketchup", "Hot Onion Dog", 12.5f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("efac8b2a-c966-4b15-83a4-8716855d3b27"), "HotDogs", "Hot dog with melted gouda cheese and bacon", "Bacon Melt", 15f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("09727a40-bd9b-4bc7-83cc-0e64c9d75e9c"), "Extras", "Regular fries", "Fries", 7.5f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("b9c775d4-b160-4528-aced-dc36e3110133"), "Drinks", "Coke bottle", "Coke", 5f });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("8af2b5c0-a6fe-4c49-a748-9ec50e833d02"), "customer@gmail.com", "B6C45863875E34487CA3C155ED145EFE12A74581E27BEFEC5AA661B8EE8CA6DD", 0, "customer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("4a14a992-0c7d-472b-92e4-082e525a7c47"), "admin@gmail.com", "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918", 3, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("e0798259-73a2-460a-84a6-c34b97ea024d"), "operator@gmail.com", "06E55B633481F7BB072957EABCF110C972E86691C3CFEDABE088024BFFE42F23", 1, "operator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("70f1a609-a6f2-4152-9dd7-9246f6502a27"), "supplier@gmail.com", "955ED10B73D6265B1ADCF768B94F8DD5D91F33309DB94B6B3AF4EFA822F1D9AF", 2, "supplier" });

            migrationBuilder.InsertData(
                table: "HotDogStandProduct",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("da123ad9-c972-4d6b-a73a-5bc9ec2c86ba"), new Guid("91627bef-b215-4fcb-a639-caba212daf71"), 7, new Guid("12bd8fbf-967a-422d-b385-b47aba932514") });

            migrationBuilder.InsertData(
                table: "HotDogStandProduct",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("fbf2c7e6-6cbd-4537-9068-698f6d93d68a"), new Guid("91627bef-b215-4fcb-a639-caba212daf71"), 20, new Guid("6dd91e54-82b9-4a6e-a4f4-076b0d8994d0") });

            migrationBuilder.InsertData(
                table: "HotDogStandProduct",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("262a9b55-2ea1-4453-a80d-aba55b3d6016"), new Guid("7c323cb5-ff68-48e5-9bee-33efeb01f85d"), 10, new Guid("12bd8fbf-967a-422d-b385-b47aba932514") });

            migrationBuilder.InsertData(
                table: "HotDogStandProduct",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("535b43aa-3ac6-4c14-9a6d-73c4f8861d11"), new Guid("7c323cb5-ff68-48e5-9bee-33efeb01f85d"), 6, new Guid("6dd91e54-82b9-4a6e-a4f4-076b0d8994d0") });

            migrationBuilder.InsertData(
                table: "HotDogStandProduct",
                columns: new[] { "Id", "ProductId", "Quantity", "StandId" },
                values: new object[] { new Guid("8bfc5c93-626e-419d-9507-f414cc80994b"), new Guid("efac8b2a-c966-4b15-83a4-8716855d3b27"), 13, new Guid("12bd8fbf-967a-422d-b385-b47aba932514") });

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
