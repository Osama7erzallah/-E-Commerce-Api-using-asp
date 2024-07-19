using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<OrderDetiles> OrderDetiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetiles>().HasKey(x=>new{x.Id,x.OrderId,x.ProductId});

            modelBuilder.Entity<Categories>().HasData(
    new Categories { Id = 1, Name = "Electronics", description = "Devices and gadgets" },
    new Categories { Id = 2, Name = "Books", description = "Books and literature" },
    new Categories { Id = 3, Name = "Clothing", description = "Apparel and accessories" },
    new Categories { Id = 4, Name = "Home Appliances", description = "Household items and appliances" },
    new Categories { Id = 5, Name = "Toys", description = "Toys and games for children" }
);

            modelBuilder.Entity<LocalUser>().HasData(
                new LocalUser { Id = 1, Name = "Ahmed Haggag", Email = "ahmed@example.com", Password = "password123", Phone = "1234567890", Role = "Admin" },
                new LocalUser { Id = 2, Name = "Tarek Sharim", Email = "tarek@example.com", Password = "password456", Phone = "0987654321", Role = "User" },
                new LocalUser { Id = 3, Name = "Sara Ali", Email = "sara@example.com", Password = "password789", Phone = "1122334455", Role = "User" }
            );

            modelBuilder.Entity<Products>().HasData(
                new Products { Id = 1, Name = "Smartphone", Price = 299.99m, image = "smartphone.jpg", CategoryId = 1 },
                new Products { Id = 2, Name = "Laptop", Price = 799.99m, image = "laptop.jpg", CategoryId = 1 },
                new Products { Id = 3, Name = "Novel", Price = 19.99m, image = "novel.jpg", CategoryId = 2 },
                new Products { Id = 4, Name = "T-Shirt", Price = 9.99m, image = "tshirt.jpg", CategoryId = 3 },
                new Products { Id = 5, Name = "Jeans", Price = 49.99m, image = "jeans.jpg", CategoryId = 3 },
                new Products { Id = 6, Name = "Washing Machine", Price = 499.99m, image = "washing_machine.jpg", CategoryId = 4 },
                new Products { Id = 7, Name = "Microwave", Price = 99.99m, image = "microwave.jpg", CategoryId = 4 },
                new Products { Id = 8, Name = "Teddy Bear", Price = 14.99m, image = "teddy_bear.jpg", CategoryId = 5 },
                new Products { Id = 9, Name = "Toy Car", Price = 9.99m, image = "toy_car.jpg", CategoryId = 5 }
            );

            modelBuilder.Entity<Orders>().HasData(
                new Orders { Id = 1, OrderStatus = "Pending", OrderDate = new DateTime(2023, 12, 11), LocalUserId = 1 },
                new Orders { Id = 2, OrderStatus = "Completed", OrderDate = new DateTime(2023, 12, 12), LocalUserId = 2 },
                new Orders { Id = 3, OrderStatus = "Shipped", OrderDate = new DateTime(2023, 12, 13), LocalUserId = 1 },
                new Orders { Id = 4, OrderStatus = "Pending", OrderDate = new DateTime(2023, 12, 14), LocalUserId = 3 },
                new Orders { Id = 5, OrderStatus = "Completed", OrderDate = new DateTime(2023, 12, 15), LocalUserId = 3 }
            );

            modelBuilder.Entity<OrderDetiles>().HasData(
                new OrderDetiles { Id = 1, OrderId = 1, ProductId = 1, Price = 299.99m, Quantity = 1 },
                new OrderDetiles { Id = 2, OrderId = 1, ProductId = 4, Price = 9.99m, Quantity = 2 },
                new OrderDetiles { Id = 3, OrderId = 2, ProductId = 3, Price = 19.99m, Quantity = 1 },
                new OrderDetiles { Id = 4, OrderId = 3, ProductId = 2, Price = 799.99m, Quantity = 1 },
                new OrderDetiles { Id = 5, OrderId = 3, ProductId = 5, Price = 49.99m, Quantity = 1 },
                new OrderDetiles { Id = 6, OrderId = 4, ProductId = 6, Price = 499.99m, Quantity = 1 },
                new OrderDetiles { Id = 7, OrderId = 4, ProductId = 8, Price = 14.99m, Quantity = 2 },
                new OrderDetiles { Id = 8, OrderId = 5, ProductId = 7, Price = 99.99m, Quantity = 1 },
                new OrderDetiles { Id = 9, OrderId = 5, ProductId = 9, Price = 9.99m, Quantity = 3 }
            );


            base.OnModelCreating(modelBuilder);
        }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        
        }

    }
}
