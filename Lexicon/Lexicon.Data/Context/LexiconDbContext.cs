
using Microsoft.EntityFrameworkCore;
using Lexicon.Data.Models;

namespace Lexicon.Data.Context
{
    public class LexiconDbContext : DbContext
    {
        public LexiconDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlServer("Server=SUNDAR-PICHAI\\MSSQLSERVER06;Database=LexiconDB;Trusted_Connection=True;Encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matter>()
                        .HasKey(m => m.Id)
                        .HasName("PrimaryKey_MatterId");

            modelBuilder.Entity<Jurisdiction>()
                        .HasKey(j => j.Id)
                        .HasName("PrimaryKey_JurisdictionId");

            modelBuilder.Entity<Client>()
                        .HasKey(c => c.Id)
                        .HasName("PrimaryKey_ClientId");

            modelBuilder.Entity<Attorney>()
                        .HasKey(a => a.Id)
                        .HasName("PrimaryKey_AttorneyId");

            modelBuilder.Entity<Invoice>()
                        .HasKey(i => i.Id)
                        .HasName("PrimaryKey_InvoiceId");

            modelBuilder.Entity<Jurisdiction>()
                        .HasMany(e => e.Attorneys)
                        .WithOne(e => e.Jurisdiction)
                        .HasForeignKey(e => e.JurisdictionId)
                        .IsRequired(false);

            modelBuilder.Entity<Jurisdiction>()
                        .HasMany(e => e.Matters)
                        .WithOne(e => e.Jurisdiction)
                        .HasForeignKey(e => e.JurisdictionId)
                        .IsRequired(false);

            modelBuilder.Entity<Client>()
                        .HasMany(e => e.Matters)
                        .WithOne(e => e.Client)
                        .HasForeignKey(e => e.ClientId)
                        .IsRequired(false);

            modelBuilder.Entity<Attorney>()
                        .HasMany(e => e.BillingAttorneyMatters)
                        .WithOne(e => e.BillingAttorney)
                        .HasForeignKey(e => e.BillingAttorneyId)
                        .IsRequired(false);

            modelBuilder.Entity<Attorney>()
                        .HasMany(e => e.ResponsibleAttorneyMatters)
                        .WithOne(e => e.ResponsibleAttorney)
                        .HasForeignKey(e => e.ResponsibleAttorneyId)
                        .IsRequired(false);

            modelBuilder.Entity<Attorney>()
                        .HasMany(e => e.Invoices)
                        .WithOne(e => e.Attorney)
                        .HasForeignKey(e => e.AttorneyId)
                        .IsRequired(false);

            modelBuilder.Entity<Matter>()
                        .HasMany(e => e.Invoices)
                        .WithOne(e => e.Matter)
                        .HasForeignKey(e => e.MatterId)
                        .IsRequired(false);


        }
        public DbSet<Jurisdiction> Jurisdictions { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Attorney> Attorneys { get; set; }
        public DbSet<Invoice>  Invoices { get; set; }
        public DbSet<Matter> Matters { get; set; }
    }
}
