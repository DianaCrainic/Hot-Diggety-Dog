using Microsoft.EntityFrameworkCore;
using System;
using WebAPI.Entities;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<HotDogStand> HotDogStands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetHotDogStandProperties(modelBuilder);
            SetProductProperties(modelBuilder);

            SeedHotDogStands(modelBuilder);
            SeedProducts(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SetHotDogStandProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotDogStand>()
                .Property(s => s.Id)
                .HasColumnName("id");

            modelBuilder.Entity<HotDogStand>()
                .Property(s => s.Address)
                .IsRequired()
                .HasColumnName("address");
        }

        private void SetProductProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .HasColumnName("id");

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("name");

            modelBuilder.Entity<Product>()
               .Property(p => p.Description)
               .HasMaxLength(500)
               .IsRequired()
               .HasColumnName("description");

            modelBuilder.Entity<Product>()
               .Property(p => p.Category)
               .HasMaxLength(100)
               .IsRequired()
               .HasColumnName("category");
        }
        private void SeedHotDogStands(ModelBuilder model)
        {
            model.Entity<HotDogStand>()
                .HasData(
                    new HotDogStand { Id = Guid.NewGuid(), Address = "Grimmer's Road" },
                    new HotDogStand { Id = Guid.NewGuid(), Address = "Fieldfare Banks" },
                    new HotDogStand { Id = Guid.NewGuid(), Address = "Imperial Passage" },
                    new HotDogStand { Id = Guid.NewGuid(), Address = "Woodville Square" },
                    new HotDogStand { Id = Guid.NewGuid(), Address = "Lindsey Circle" },
                    new HotDogStand { Id = Guid.NewGuid(), Address = "Alexander Banks" }
                );
        }

        private void SeedProducts(ModelBuilder model)
        {
            model.Entity<Product>()
                .HasData(
                    new Product { Id = Guid.NewGuid(), Name = "Hot Dog", Description = "Basic hot dog with ketchup/mustard", Category = "HotDogs" },
                    new Product { Id = Guid.NewGuid(), Name = "Hot Onion Dog", Description = "Hot dog with caramelized onions and ketchup", Category = "HotDogs" },
                    new Product { Id = Guid.NewGuid(), Name = "Bacon Melt", Description = "Hot dog with melted gouda cheese and bacon", Category = "HotDogs" },
                    new Product { Id = Guid.NewGuid(), Name = "Fries", Description = "Regular fries", Category = "Extras" },
                    new Product { Id = Guid.NewGuid(), Name = "Coke", Description = "Cola bottle", Category = "Drinks" }
                );
        }
    }
}
