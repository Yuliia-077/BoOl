using BoOl.Application.Models.Users;
using BoOl.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(SignInManager<User> signInManager,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
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

        public async Task<IList<string>> GetAllRoleName()
        {
            return await _roleManager.Roles.Select(x => x.Name).ToListAsync();
        }

        public async Task<IdentityResult> CreateUser(RegisterDto dto)
        {
            User user = new User { Email = dto.Email, UserName = dto.Email, WorkerId = dto.WorkerId };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {

                await _userManager.AddToRolesAsync(user, dto.UserRoles);
            }
            return result;
        }
    }
}
