using BoOl.Application.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Users
{
    public interface IUserService
    {
        Task<bool> LogIn(LogInDto dto);
        Task LogOut();
        Task<IList<string>> GetAllRoleName();
        Task<IdentityResult> CreateUser(RegisterDto dto);
    }
}
