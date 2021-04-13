using Microsoft.EntityFrameworkCore;
using System;
using System.Web.Helpers;
using WebAPI.Data;
using WebAPI.Entities;

namespace HotDiggetyDogTests
{
    public class ControllersFixture : IDisposable
    {
        public DataContext DataContext { get; private set; }

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

        private void SeedUsers()
        {
            DataContext.Users.Add(new User { Id = Guid.Parse("3d2be2e4-44f0-446e-a29e-3f73a7aa7274"), Username = "UserName1", Email = "username1@gmail.com", Password = Crypto.SHA256("UserName1") });
            DataContext.Users.Add(new User { Id = Guid.Parse("6065a7de-89f1-4220-8349-2c1f474ddda8"), Username = "UserName2", Email = "username2@gmail.com", Password = Crypto.SHA256("UserName2") });
        }

        public void SeedHotDogStands()
        {
            DataContext.HotDogStands.Add(new HotDogStand { Id = Guid.Parse("154b9350-ccef-4ab1-aa7a-9eddc0b3cd6a"), Address = "Grimmer's Road" });
            DataContext.HotDogStands.Add(new HotDogStand { Id = Guid.Parse("2d6e0358-3307-409f-90d4-4656f5c63e7f"), Address = "Fieldfare Banks" });
            DataContext.HotDogStands.Add(new HotDogStand { Id = Guid.Parse("4a2c24e5-e64c-4471-b510-d8e9e1bf8ad0"), Address = "Imperial Passage" });
        }

        public void SeedProducts()
        {
            DataContext.Products.Add(new Product { Id = Guid.Parse("15a5c583-f1d5-444c-b142-8fccffcc394a"), Name = "Hot Dog", Description = "Basic hot dog with ketchup/mustard", Category = "HotDogs", Price = 10 });
            DataContext.Products.Add(new Product { Id = Guid.Parse("e9440e2d-a0d8-4bf9-ad21-2d93ed664eef"), Name = "Hot Onion Dog", Description = "Hot dog with caramelized onions and ketchup", Category = "HotDogs", Price = 12.5F });
            DataContext.Products.Add(new Product { Id = Guid.Parse("7c98a2ff-fb67-4a4a-b051-9adbcb18b63e"), Name = "Bacon Melt", Description = "Hot dog with melted gouda cheese and bacon", Category = "HotDogs", Price = 15 });
            DataContext.Products.Add(new Product { Id = Guid.Parse("526d5941-3492-49cd-9218-dedaafc81d24"), Name = "Fries", Description = "Regular fries", Category = "Extras", Price = 7.5F });
        }

        public void Dispose()
        {
            DataContext.HotDogStands.RemoveRange(DataContext.HotDogStands);
            DataContext.Users.RemoveRange(DataContext.Users);
            DataContext.Products.RemoveRange(DataContext.Products);
            DataContext.SaveChanges();
        }
    }
}
