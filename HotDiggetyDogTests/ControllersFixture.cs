using Microsoft.EntityFrameworkCore;
using System;
using System.Web.Helpers;
using WebAPI.Data;
using WebAPI.Entities;

namespace HotDiggetyDogTests
{
    public class ControllersFixture
    {
        public DataContext DataContext { get; private set; }


        private void SeedUsers()
        {
            DataContext.Users.Add(new User { Id = new Guid("ec6e8b21-1334-42f4-9124-2201ee5401b7"), Username = "UserName1", Email = "username1@gmail.com", Password = Crypto.SHA256("UserName1") });
            DataContext.Users.Add(new User { Id = new Guid("6f9f568f-76e6-4972-bee3-07432fdbf9d0"), Username = "UserName2", Email = "username2@gmail.com", Password = Crypto.SHA256("UserName2") });
        }

        public void SeedHotDogStands()
        {
            DataContext.HotDogStands.Add(new HotDogStand { Id = new Guid("7eec2844-334b-4590-a95d-f93adfa04f69"), Address = "Grimmer's Road" });
            DataContext.HotDogStands.Add(new HotDogStand { Id = new Guid("5efe7a02-be40-4f6c-b1aa-ca8c06de1ce0"), Address = "Fieldfare Banks"});
            DataContext.HotDogStands.Add(new HotDogStand { Id = new Guid("f28c6ea4-6f6e-4cd9-9dbd-0193625730f0"), Address = "Imperial Passage"});
        }

        public void SeedProducts()
        {
            DataContext.Products.Add(new Product { Id = new Guid("ccb86b0e-fd65-48bc-9345-220999b10caf"), Name = "Hot Dog", Description = "Basic hot dog with ketchup/mustard", Category = "HotDogs", Price = 10 });
            DataContext.Products.Add(new Product { Id = new Guid("0486a413-f167-409c-8b73-577d99d405ca"), Name = "Hot Onion Dog", Description = "Hot dog with caramelized onions and ketchup", Category = "HotDogs", Price = 12.5F });
            DataContext.Products.Add(new Product { Id = new Guid("0c0eab8a-ce52-4865-9903-ab2a75d5820c"), Name = "Bacon Melt", Description = "Hot dog with melted gouda cheese and bacon", Category = "HotDogs", Price = 15 });
            DataContext.Products.Add(new Product { Id = new Guid("5a536260-f54f-4048-b56d-4e95001d2292"), Name = "Fries", Description = "Regular fries", Category = "Extras", Price = 7.5F });
         }

        public ControllersFixture()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                    .UseInMemoryDatabase(databaseName: "HotDogDatabase")
                    .Options;

            DataContext = new DataContext(options);
            SeedUsers();
            SeedHotDogStands();
            SeedProducts();
            DataContext.SaveChanges();
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }
    }
}
