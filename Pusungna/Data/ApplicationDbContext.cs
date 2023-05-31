using Microsoft.EntityFrameworkCore;
using Pusungna.Models;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace Pusungna.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _config;
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_config.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 21)));
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<BlogPost> BlogPosts { get; set; } = null!;
    }
}
