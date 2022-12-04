using BoOl.Application.Models.Users;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Users
{
    public interface IUserService
    {
        Task<bool> LogIn(LogInDto dto);
        Task LogOut();
    }
}
