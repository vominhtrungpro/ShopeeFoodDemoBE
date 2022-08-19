using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.EF.Data
{
    public class DataContext : DbContext
    {
        //public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("EF/appsettings.json")
        //        .Build();
        //    var connectionString = configuration.GetConnectionString("DefaultConnection");
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
            .HasOne<Customer>(s => s.Customer)
            .WithMany(g => g.Order)
            .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<OrderDetail>()
            .HasOne<Order>(s => s.Order)
            .WithMany(g => g.OrderDetail)
            .HasForeignKey(s => s.OrderId);

            modelBuilder.Entity<OrderDetail>()
            .HasOne<Product>(s => s.Product)
            .WithMany(g => g.OrderDetail)
            .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<Product>()
            .HasOne<Menu>(s => s.Menu)
            .WithMany(g => g.Product)
            .HasForeignKey(s => s.MenuId);

            modelBuilder.Entity<OrderDetail>()
            .HasOne<Order>(s => s.Order)
            .WithMany(g => g.OrderDetail)
            .HasForeignKey(s => s.OrderId);

            modelBuilder.Entity<ItemOption>()
            .HasOne<Product>(s => s.Product)
            .WithMany(g => g.ItemOption)
            .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<ItemOption>()
            .HasOne<Option>(s => s.Option)
            .WithMany(g => g.ItemOpstion)
            .HasForeignKey(s => s.ItemOptionId);

            modelBuilder.Entity<Option>()
            .HasOne<OptionType>(s => s.OptionType)
            .WithMany(g => g.Option)
            .HasForeignKey(s => s.OptionTypeId);

            modelBuilder.Entity<Menu>()
            .HasOne<Restaurant>(s => s.Restaurant)
            .WithMany(g => g.Menu)
            .HasForeignKey(s => s.RestaurantId);

            modelBuilder.Entity<Restaurant>()
            .HasOne<City>(s => s.City)
            .WithMany(g => g.Restaurant)
            .HasForeignKey(s => s.CityId);

            modelBuilder.Entity<Restaurant>()
           .HasOne<RestaurantType>(s => s.RestaurantType)
           .WithMany(g => g.Restaurant)
           .HasForeignKey(s => s.RestaurantTypeId);

            modelBuilder.Entity<RestaurantType>()
           .HasOne<Category>(s => s.Category)
           .WithMany(g => g.RestaurantType)
           .HasForeignKey(s => s.CategoryId);
        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<ItemOption> ItemOption { get; set; }

        public DbSet<Menu> Menu { get; set; }

        public DbSet<Option> Option { get; set; }

        public DbSet<OptionType> OptionType { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Restaurant> Restaurant { get; set; }

        public DbSet<RestaurantType> RestaurantType { get; set; }
    }
}
