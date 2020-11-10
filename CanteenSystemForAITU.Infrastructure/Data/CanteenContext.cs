using CanteenSystemForAITU.Domain.Models;

using Microsoft.EntityFrameworkCore;
using ProjectForAITUCanteen.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class CanteenContext : DbContext
    {
        public CanteenContext(DbContextOptions<CanteenContext> options) : base(options)
        {

        }
        public DbSet<Product> Items { get; set; }
        public DbSet<Item> Products { get; set; }
        public DbSet<Student> StudentList { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderProduct>().HasKey(x => new { x.ProductId, x.OrderId });
        }
    }
}
