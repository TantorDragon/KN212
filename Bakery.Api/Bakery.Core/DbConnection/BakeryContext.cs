using Bakery.Core.DbConnection.ModelConfigurations;
using Bakery.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Core.DbConnection
{
    public class BakeryContext : DbContext
    {
        public BakeryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrdersConfiguration());
            builder.ApplyConfiguration(new UsersConfiguration());
            builder.ApplyConfiguration(new ProductsConfiguration());

        }
        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
