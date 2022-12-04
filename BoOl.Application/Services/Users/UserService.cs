using BoOl.Application.Models.Users;
using BoOl.Domain;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly SignInManager<User> _signInManager;

        public UserService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;

        }

        public async Task<bool> LogIn(LogInDto dto)
        {
            var result =
                   await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, dto.RememberMe, false);
            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
