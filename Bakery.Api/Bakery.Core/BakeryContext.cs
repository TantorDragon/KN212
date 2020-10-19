using Bakery.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bakery.Core
{
    public class BakeryContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
