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

        private void SeedUsers()
        {
            DataContext.Users.Add(new User { Id = Guid.NewGuid(), Username = "UserName1", Email = "username1@gmail.com", Password = Crypto.SHA256("UserName1") });
            DataContext.Users.Add(new User { Id = Guid.NewGuid(), Username = "UserName2", Email = "username2@gmail.com", Password = Crypto.SHA256("UserName2") });
        }

        public void SeedHotDogStands()
        {
            DataContext.HotDogStands.Add(new HotDogStand { Id = Guid.NewGuid(), Address = "Grimmer's Road" });
            DataContext.HotDogStands.Add(new HotDogStand { Id = Guid.NewGuid(), Address = "Fieldfare Banks" });
            DataContext.HotDogStands.Add(new HotDogStand { Id = Guid.NewGuid(), Address = "Imperial Passage" });
        }

        public void SeedProducts()
        {
            DataContext.Products.Add(new Product { Id = Guid.NewGuid(), Name = "Hot Dog", Description = "Basic hot dog with ketchup/mustard", Category = "HotDogs", Price = 10 });
            DataContext.Products.Add(new Product { Id = Guid.NewGuid(), Name = "Hot Onion Dog", Description = "Hot dog with caramelized onions and ketchup", Category = "HotDogs", Price = 12.5F });
            DataContext.Products.Add(new Product { Id = Guid.NewGuid(), Name = "Bacon Melt", Description = "Hot dog with melted gouda cheese and bacon", Category = "HotDogs", Price = 15 });
            DataContext.Products.Add(new Product { Id = Guid.NewGuid(), Name = "Fries", Description = "Regular fries", Category = "Extras", Price = 7.5F });
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
