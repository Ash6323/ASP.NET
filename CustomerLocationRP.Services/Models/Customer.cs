
using Microsoft.EntityFrameworkCore;

namespace CustomerLocationRP.Services.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public List<Address> Locations { get; set; } = new List<Address>();
    }
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
