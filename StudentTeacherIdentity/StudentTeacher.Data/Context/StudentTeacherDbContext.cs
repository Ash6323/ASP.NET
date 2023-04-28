using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentTeacher.Data.Models;

namespace StudentTeacher.Data.Context
{
    public class StudentTeacherDbContext : IdentityDbContext<User>
    {
        public StudentTeacherDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlServer("Server=SUNDAR-PICHAI\\MSSQLSERVER06;Database=StudentTeacherDB;Trusted_Connection=True;Encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                        .HasKey(s => s.Id)
                        .HasName("PrimaryKey_StudentId");

            modelBuilder.Entity<Teacher>()
                        .HasKey(t => t.Id)
                        .HasName("PrimaryKey_TeacherId");

            modelBuilder.Entity<Teacher>()
                        .HasMany(e => e.Students)
                        .WithOne(e => e.Teacher)
                        .HasForeignKey(e => e.TeacherId)
                        .IsRequired(false);

            //modelBuilder.Entity<User>()
            //            .HasNoKey();

            modelBuilder.ApplyConfiguration(new TeacherData());
            modelBuilder.ApplyConfiguration(new StudentData());
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
