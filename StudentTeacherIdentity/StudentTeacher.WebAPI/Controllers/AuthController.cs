using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentTeacher.Data.DTOs;
using StudentTeacher.Service.Filters;
using StudentTeacher.Service.Interfaces;

namespace StudentTeacher.WebAPI.Controllers
{
    [Route("api/userauthentication")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        protected readonly IRepositoryManager _repository;
        protected readonly ILoggerManager _logger;
        protected readonly IMapper _mapper;
        public AuthController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistration)
        {
            var userResult = await _repository.UserAuthentication.RegisterUserAsync(userRegistration);
            return !userResult.Succeeded ? new BadRequestObjectResult(userResult) : StatusCode(201);
        }
    }
}
