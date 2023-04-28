using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentTeacher.Data.Models;

namespace StudentTeacher.Data.Context
{
    public class TeacherData : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasData(
                new Teacher
                {
                    Id = 1,
                    Name = "John",
                    Subject = "React"
                },

                new Teacher
                {
                    Id = 2,
                    Name = "Femi",
                    Subject = "ASP.NET Core"
                });
        }
    }

}
