using AutoMapper;
using StudentTeacher.Data.DTOs;
using StudentTeacher.Data.Models;

namespace StudentTeacher.Data.Mappings
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<Student, StudentDto>();

            CreateMap<StudentCreationDto, Student>();

            CreateMap<StudentUpdateDto, Student>().ReverseMap();
        }
    }
}
