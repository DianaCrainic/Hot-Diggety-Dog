using System;
using System.Linq;
using System.Web.Helpers;
using WebAPI.Data.Context;
using WebAPI.Entities;

namespace HotDiggetyDogTests
{
    class DatabaseInitializer
    {
        public static void Initialize(DataContext dataContext)
        {
            if (dataContext.Products.Any() || dataContext.Users.Any() || 
                dataContext.HotDogStands.Any() || dataContext.Orders.Any())
            {
                return;
            }

            Seed(dataContext);
        }

        private static void Seed(DataContext dataContext)
        {
            SeedUsers(dataContext);
            SeedHotDogStands(dataContext);
            SeedProducts(dataContext);
        }

        private static void SeedUsers(DataContext dataContext)
        {
            User[] users = new[] {
                new User { Id = new Guid("3d2be2e4-44f0-446e-a29e-3f73a7aa7274"), Username = "customer", Email = "customer@gmail.com", Password = Crypto.SHA256("customer"), Role = Role.CUSTOMER },
                new User { Id = new Guid("6065a7de-89f1-4220-8349-2c1f474ddda8"), Username = "admin", Email = "admin@gmail.com", Password = Crypto.SHA256("admin"), Role = Role.ADMIN },
                new User { Id = new Guid("1c3ea0d2-8fb1-429f-a6f8-41de7ab9aa3e"), Username = "operator", Email = "operator@gmail.com", Password = Crypto.SHA256("operator"), Role = Role.OPERATOR },
                new User { Id = new Guid("13ca072a-ee86-4eba-8f40-cc28bb44ef0f"), Username = "supplier", Email = "supplier@gmail.com", Password = Crypto.SHA256("supplier"), Role = Role.SUPPLIER }
            };

            dataContext.AddRange(users);
            dataContext.SaveChanges();
        }

        private static void SeedHotDogStands(DataContext dataContext)
        {
            var stands = new[] {
                new HotDogStand { Id = Guid.Parse("154b9350-ccef-4ab1-aa7a-9eddc0b3cd6a"), Address = "Grimmer's Road" },
                new HotDogStand { Id = Guid.Parse("2d6e0358-3307-409f-90d4-4656f5c63e7f"), Address = "Fieldfare Banks" },
                new HotDogStand { Id = Guid.Parse("4a2c24e5-e64c-4471-b510-d8e9e1bf8ad0"), Address = "Imperial Passage" }
            };

            dataContext.AddRange(stands);
            dataContext.SaveChanges();
        }

        private static void SeedProducts(DataContext dataContext)
        {
            var products = new[] {
                new Product { Id = Guid.Parse("15a5c583-f1d5-444c-b142-8fccffcc394a"), Name = "Hot Dog", Description = "Basic hot dog with ketchup/mustard", Category = "HotDogs", Price = 10 },
                new Product { Id = Guid.Parse("e9440e2d-a0d8-4bf9-ad21-2d93ed664eef"), Name = "Hot Onion Dog", Description = "Hot dog with caramelized onions and ketchup", Category = "HotDogs", Price = 12.5F },
                new Product { Id = Guid.Parse("7c98a2ff-fb67-4a4a-b051-9adbcb18b63e"), Name = "Bacon Melt", Description = "Hot dog with melted gouda cheese and bacon", Category = "HotDogs", Price = 15 },
                new Product { Id = Guid.Parse("526d5941-3492-49cd-9218-dedaafc81d24"), Name = "Fries", Description = "Regular fries", Category = "Extras", Price = 7.5F }
            };

            dataContext.AddRange(products);
            dataContext.SaveChanges();
        }
    }
}
