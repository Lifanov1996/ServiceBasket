using Microsoft.EntityFrameworkCore;
using ServiceBasket.Models;

namespace ServiceBasket.Data
{
    public class ContextDB: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }   
        public DbSet<Order2Product> Orders2Products { get; set; }

        public ContextDB(DbContextOptions options) : base(options) { }
    }
}
