using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Web.Helpers;

namespace Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<HotDogStand> HotDogStands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrdersProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetUserProperties(modelBuilder);
            SetHotDogStandProperties(modelBuilder);
            SetProductProperties(modelBuilder);
            SetOrderProperties(modelBuilder);
            SetOrderProductProperties(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SetOrderProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(o => o.Id)
                .HasColumnName("id");
            modelBuilder.Entity<Order>()
                .Property(op => op.OperatorId)
                .HasColumnName("operator_id");
            modelBuilder.Entity<Order>()
                .Property(o => o.UserId)
                .HasColumnName("user_id");
            modelBuilder.Entity<Order>()
                .Property(o => o.Timestamp)
                .HasColumnName("timesptamp");
            modelBuilder.Entity<Order>()
                .Property(o => o.Total)
                .HasColumnName("total");
        }

        private static void SetOrderProductProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .Property(o => o.Id)
                .HasColumnName("id");
            modelBuilder.Entity<OrderProduct>()
                .Property(o => o.OrderId)
                .HasColumnName("order_id");
            modelBuilder.Entity<OrderProduct>()
                .Property(p => p.ProductId)
                .HasColumnName("product_id");
            modelBuilder.Entity<OrderProduct>()
                .Property(q => q.Quantity)
                .HasColumnName("quantity");
        }

        private static void SetUserProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .HasColumnName("id");
            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired()
                .HasColumnName("username");
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasColumnName("email");
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .IsRequired()
                .HasColumnName("role");
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired()
                .HasColumnName("password");
        }

        private static void SetHotDogStandProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotDogStand>()
                .Property(s => s.Id)
                .HasColumnName("id");
            modelBuilder.Entity<HotDogStand>()
                .Property(s => s.Address)
                .IsRequired()
                .HasColumnName("address");
        }

        private static void SetProductProperties(ModelBuilder modelBuilder)
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

        private static void SeedUsers(ModelBuilder model)
        {
            model.Entity<User>()
                .HasData(
                    new User { Id = Guid.NewGuid(), Username = "customer", Email = "customer@gmail.com", Password = Crypto.SHA256("customer"), Role = Role.CUSTOMER },
                    new User { Id = Guid.NewGuid(), Username = "admin", Email = "admin@gmail.com", Password = Crypto.SHA256("admin"), Role = Role.ADMIN },
                    new User { Id = Guid.NewGuid(), Username = "operator", Email = "operator@gmail.com", Password = Crypto.SHA256("operator"), Role = Role.OPERATOR },
                    new User { Id = Guid.NewGuid(), Username = "supplier", Email = "supplier@gmail.com", Password = Crypto.SHA256("supplier"), Role = Role.SUPPLIER }
                );
        }

        private static void SeedHotDogStands(ModelBuilder model)
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

        private static void SeedProducts(ModelBuilder model)
        {
            model.Entity<Product>()
                .HasData(
                    new Product { Id = Guid.NewGuid(), Name = "Hot Dog", Description = "Basic hot dog with ketchup/mustard", Category = "HotDogs", Price = 10 },
                    new Product { Id = Guid.NewGuid(), Name = "Hot Onion Dog", Description = "Hot dog with caramelized onions and ketchup", Category = "HotDogs", Price = 12.5F },
                    new Product { Id = Guid.NewGuid(), Name = "Bacon Melt", Description = "Hot dog with melted gouda cheese and bacon", Category = "HotDogs", Price = 15 },
                    new Product { Id = Guid.NewGuid(), Name = "Fries", Description = "Regular fries", Category = "Extras", Price = 7.5F },
                    new Product { Id = Guid.NewGuid(), Name = "Coke", Description = "Coke bottle", Category = "Drinks", Price = 5 }
                );
        }
    }
}