using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class UserRoleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotDogStands",
                keyColumn: "id",
                keyValue: new Guid("1b4c8b59-cff8-4eb3-a810-7ea61a9f7343"));

            migrationBuilder.DeleteData(
                table: "HotDogStands",
                keyColumn: "id",
                keyValue: new Guid("5702456f-f920-45d7-a581-bb9276eaacb6"));

            migrationBuilder.DeleteData(
                table: "HotDogStands",
                keyColumn: "id",
                keyValue: new Guid("62771aa8-3da0-40d4-8561-bafe232f8e39"));

            migrationBuilder.DeleteData(
                table: "HotDogStands",
                keyColumn: "id",
                keyValue: new Guid("6345ddac-e3d2-4254-84e6-5f722d8985bd"));

            migrationBuilder.DeleteData(
                table: "HotDogStands",
                keyColumn: "id",
                keyValue: new Guid("90cd1ae4-af96-4e69-b8b3-9ea98ea7ef0e"));

            migrationBuilder.DeleteData(
                table: "HotDogStands",
                keyColumn: "id",
                keyValue: new Guid("e2656c55-c558-401e-94f4-547397a5973c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: new Guid("074aa619-635b-4e18-89e2-b74add2b0332"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: new Guid("18bd4ee8-bff7-4f15-9cb5-24204ae414f0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: new Guid("9d6de5b5-1343-4cd5-be34-14d3d0e5d515"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: new Guid("a35bca61-1bc9-44d8-b1a0-e4b0cd9639c9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: new Guid("d728feb5-d16c-4929-8339-aef0c9681176"));

            migrationBuilder.AddColumn<int>(
                name: "role",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("c7d40123-7e01-44d4-bc2a-3a82872c6f20"), "Grimmer's Road" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("8cb4c5f0-0ff9-49f0-87df-6852d78f5601"), "Fieldfare Banks" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("9acfa6fd-7bf5-40e5-8019-0212ab39da0d"), "Imperial Passage" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("33d0cf59-33fc-425a-ac5c-622137759ed8"), "Woodville Square" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("ec4ac133-0b8f-49f3-b0b0-e89f5a2d2f9b"), "Lindsey Circle" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("0b864e0b-c85c-461d-ac25-8d135da5efd2"), "Alexander Banks" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("97f454b0-a44c-407e-a7ba-26d2b42de062"), "HotDogs", "Basic hot dog with ketchup/mustard", "Hot Dog", 10f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("8acf400e-45a3-447e-ad44-a70dfd26a7da"), "HotDogs", "Hot dog with caramelized onions and ketchup", "Hot Onion Dog", 12.5f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("8ed02c83-36ea-45af-a728-5e250e91fd28"), "HotDogs", "Hot dog with melted gouda cheese and bacon", "Bacon Melt", 15f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("4999ecc3-fab3-4ca3-acb8-23ab800eda98"), "Extras", "Regular fries", "Fries", 7.5f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("77ab8221-e742-4712-ad85-d88e0cfd237b"), "Drinks", "Coke bottle", "Coke", 5f });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("e69e27e6-1d3c-44ab-9cb3-8f7a21e5e27d"), "customer@gmail.com", "B6C45863875E34487CA3C155ED145EFE12A74581E27BEFEC5AA661B8EE8CA6DD", 0, "customer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("dd4900c7-6025-433e-a0ee-643484b2c9ae"), "admin@gmail.com", "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918", 3, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("d2cb518b-4978-41ba-a021-eba20abcf050"), "operator@gmail.com", "06E55B633481F7BB072957EABCF110C972E86691C3CFEDABE088024BFFE42F23", 1, "operator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "password", "role", "username" },
                values: new object[] { new Guid("65e5daee-9d34-48db-b924-7581395412a9"), "supplier@gmail.com", "955ED10B73D6265B1ADCF768B94F8DD5D91F33309DB94B6B3AF4EFA822F1D9AF", 2, "supplier" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotDogStands",
                keyColumn: "id",
                keyValue: new Guid("0b864e0b-c85c-461d-ac25-8d135da5efd2"));

            migrationBuilder.DeleteData(
                table: "HotDogStands",
                keyColumn: "id",
                keyValue: new Guid("33d0cf59-33fc-425a-ac5c-622137759ed8"));

            migrationBuilder.DeleteData(
                table: "HotDogStands",
                keyColumn: "id",
                keyValue: new Guid("8cb4c5f0-0ff9-49f0-87df-6852d78f5601"));

            migrationBuilder.DeleteData(
                table: "HotDogStands",
                keyColumn: "id",
                keyValue: new Guid("9acfa6fd-7bf5-40e5-8019-0212ab39da0d"));

            migrationBuilder.DeleteData(
                table: "HotDogStands",
                keyColumn: "id",
                keyValue: new Guid("c7d40123-7e01-44d4-bc2a-3a82872c6f20"));

            migrationBuilder.DeleteData(
                table: "HotDogStands",
                keyColumn: "id",
                keyValue: new Guid("ec4ac133-0b8f-49f3-b0b0-e89f5a2d2f9b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: new Guid("4999ecc3-fab3-4ca3-acb8-23ab800eda98"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: new Guid("77ab8221-e742-4712-ad85-d88e0cfd237b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: new Guid("8acf400e-45a3-447e-ad44-a70dfd26a7da"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: new Guid("8ed02c83-36ea-45af-a728-5e250e91fd28"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: new Guid("97f454b0-a44c-407e-a7ba-26d2b42de062"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("65e5daee-9d34-48db-b924-7581395412a9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("d2cb518b-4978-41ba-a021-eba20abcf050"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("dd4900c7-6025-433e-a0ee-643484b2c9ae"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("e69e27e6-1d3c-44ab-9cb3-8f7a21e5e27d"));

            migrationBuilder.DropColumn(
                name: "role",
                table: "Users");

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("e2656c55-c558-401e-94f4-547397a5973c"), "Grimmer's Road" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("62771aa8-3da0-40d4-8561-bafe232f8e39"), "Fieldfare Banks" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("6345ddac-e3d2-4254-84e6-5f722d8985bd"), "Imperial Passage" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("90cd1ae4-af96-4e69-b8b3-9ea98ea7ef0e"), "Woodville Square" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("1b4c8b59-cff8-4eb3-a810-7ea61a9f7343"), "Lindsey Circle" });

            migrationBuilder.InsertData(
                table: "HotDogStands",
                columns: new[] { "id", "address" },
                values: new object[] { new Guid("5702456f-f920-45d7-a581-bb9276eaacb6"), "Alexander Banks" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("a35bca61-1bc9-44d8-b1a0-e4b0cd9639c9"), "HotDogs", "Basic hot dog with ketchup/mustard", "Hot Dog", 10f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("074aa619-635b-4e18-89e2-b74add2b0332"), "HotDogs", "Hot dog with caramelized onions and ketchup", "Hot Onion Dog", 12.5f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("d728feb5-d16c-4929-8339-aef0c9681176"), "HotDogs", "Hot dog with melted gouda cheese and bacon", "Bacon Melt", 15f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("9d6de5b5-1343-4cd5-be34-14d3d0e5d515"), "Extras", "Regular fries", "Fries", 7.5f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "description", "name", "Price" },
                values: new object[] { new Guid("18bd4ee8-bff7-4f15-9cb5-24204ae414f0"), "Drinks", "Cola bottle", "Coke", 5f });
        }
    }
}
