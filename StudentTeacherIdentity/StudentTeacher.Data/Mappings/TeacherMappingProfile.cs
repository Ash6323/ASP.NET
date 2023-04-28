using AutoMapper;
using StudentTeacher.Data.Context;
using StudentTeacher.Data.DTOs;
using StudentTeacher.Data.Models;

namespace StudentTeacher.Data.Mappings
{
    public class TeacherMappingProfile : Profile
    {
        public TeacherMappingProfile()
        {
            CreateMap<Teacher, TeacherDto>();

            CreateMap<TeacherCreationDto, Teacher>();

            CreateMap<TeacherUpdateDto, Teacher>().ReverseMap();
        }
    }
}
