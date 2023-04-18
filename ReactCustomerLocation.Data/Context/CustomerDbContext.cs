using ReactCustomerLocation.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ReactCustomerLocation.Data.Context
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlServer("Server=SUNDAR-PICHAI\\MSSQLSERVER06;Database=ReactCustomerLocation;Trusted_Connection=True;Encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                        .HasKey(c => c.Id)
                        .HasName("PrimaryKey_Id");
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
