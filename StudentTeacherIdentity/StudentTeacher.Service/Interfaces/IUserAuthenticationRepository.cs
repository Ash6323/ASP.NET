using Microsoft.AspNetCore.Identity;
using StudentTeacher.Data.DTOs;
using StudentTeacher.Data.Models;

namespace StudentTeacher.Service.Interfaces
{
    public interface IUserAuthenticationRepository
    {
        Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userForRegistration);
    }
}
