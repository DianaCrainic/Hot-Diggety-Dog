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

            SeedStands(modelBuilder);
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

        private void SeedStands(ModelBuilder model)
        {
            model.Entity<HotDogStand>()
                .HasData(
                new HotDogStand { Id = Guid.NewGuid(), Address = "Strada Lalelelor" },
                new HotDogStand { Id = Guid.NewGuid(), Address = "Strada Malinilor" },
                new HotDogStand { Id = Guid.NewGuid(), Address = "Strada Copou" },
                new HotDogStand { Id = Guid.NewGuid(), Address = "Strada Stramosilor" },
                new HotDogStand { Id = Guid.NewGuid(), Address = "Strada Brailei" }
                );

        }

        private void SeedProducts(ModelBuilder model)
        {
            model.Entity<Product>()
                .HasData(
                new Product { Id = Guid.NewGuid(), Name = "Ketchup Tommy", Description = "Ketchup for hot dogs", Category = "Sauce" },
                new Product { Id = Guid.NewGuid(), Name = "Happy Bunny", Description = "Bun for hot dog", Category = "Bread" },
                new Product { Id = Guid.NewGuid(), Name = "Sausage", Description = "Sausage for hot dogs", Category = "Meat" },
                new Product { Id = Guid.NewGuid(), Name = "Golden Mustard", Description = "Mustard for hot dogs", Category = "Sauce" },
                new Product { Id = Guid.NewGuid(), Name = "Vinegar oil", Description = "Oil for cooking", Category = "Oils" }
                );

        }

    }
}
