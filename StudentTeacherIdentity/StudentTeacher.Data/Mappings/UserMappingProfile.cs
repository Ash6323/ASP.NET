using AutoMapper;
using StudentTeacher.Data.DTOs;
using StudentTeacher.Data.Models;

namespace StudentTeacher.Data.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRegistrationDto, User>();
        }
    }
}
