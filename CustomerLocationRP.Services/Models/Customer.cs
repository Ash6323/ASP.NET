
using Azure;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace CustomerLocationRP.Services.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Spouse Spouse { get; set; }         //One-to-One
        public ICollection<Address> Addresses { get; set; } = new List<Address>();      //One-to-many
        public List<Product> Products { get; set; } = new();
        public List<CustomerProduct> CustomerProducts { get; } = new();
    }
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=SUNDAR-PICHAI\\MSSQLSERVER06;Database=customerDB;Trusted_Connection=True;Encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                        .HasKey(c => c.CustomerId)
                        .HasName("PrimaryKey_CustomerId");

            // Configure CustomerId as FK for Spouse
            modelBuilder.Entity<Customer>()
                        .HasOne(e => e.Spouse)
                        .WithOne(e => e.Customer)
                        .HasForeignKey<Spouse>(e => e.CustomerId)
                        .IsRequired(false);

            modelBuilder.Entity<Customer>()
                        .HasMany(e => e.Addresses)
                        .WithOne(e => e.Customer)
                        .HasForeignKey(e => e.CustomerId)
                        .IsRequired();

            modelBuilder.Entity<Customer>()
                        .HasMany(e => e.Products)
                        .WithMany(e => e.Customers)
                        .UsingEntity<CustomerProduct>(
                            l => l.HasOne<Product>(e => e.Product).WithMany(e => e.CustomerProducts),
                            r => r.HasOne<Customer>(e => e.Customer).WithMany(e => e.CustomerProducts));
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
