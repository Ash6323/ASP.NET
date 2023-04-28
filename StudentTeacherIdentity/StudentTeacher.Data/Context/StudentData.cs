using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentTeacher.Data.Models;

namespace StudentTeacher.Data.Context
{
    public class StudentData : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(
                new Student
                {
                    Id = 1,
                    Name = "Ashwin",
                    Class = "MCA",
                    TeacherId = 1
                },

                new Student
                {
                    Id = 2,
                    Name = "Piyush",
                    Class = "MCA",
                    TeacherId = 2
                },

                new Student
                {
                    Id = 3,
                    Name = "Karishma",
                    Class = "Engineering",
                    TeacherId = 1
                });
        }
    }
}
