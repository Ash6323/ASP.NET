using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using StudentTeacher.Data.Models;
using StudentTeacher.Data.Context;
using StudentTeacher.Service.Interfaces;

namespace StudentTeacher.Service.Services
{
    public class RepositoryManager : IRepositoryManager
    {
        private StudentTeacherDbContext _context;

        private ITeacherRepository _teacherRepository;
        private IStudentRepository _studentRepository;
        private IUserAuthenticationRepository _userAuthenticationRepository;
        private UserManager<User> _userManager;
        private IMapper _mapper;
        private IConfiguration _configuration;

        public RepositoryManager(StudentTeacherDbContext context, UserManager<User> userManager, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
        }
        public IUserAuthenticationRepository UserAuthentication
        {
            get
            {
                if (_userAuthenticationRepository is null)
                    _userAuthenticationRepository = new UserAuthenticationRepository(_userManager, _configuration, _mapper);
                return _userAuthenticationRepository;
            }
        }
        public Task SaveAsync() => _context.SaveChangesAsync();

        //public ITeacherRepository Teacher
        //{
        //    get
        //    {
        //        if (_teacherRepository is null)
        //            _teacherRepository = new TeacherRepository(_repositoryContext);
        //        return _teacherRepository;
        //    }
        //}
        //public IStudentRepository Student
        //{
        //    get
        //    {
        //        if (_studentRepository is null)
        //            _studentRepository = new StudentRepository(_repositoryContext);
        //        return _studentRepository;
        //    }
        //}
    }
}
