using BoOl.Application.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Введіть електронну пошту!")]
        [EmailAddress(ErrorMessage = "Електонна пошта не правильна!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введіть пароль!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static LogInDto AsDto(this LoginViewModel request)
        {
            return new LogInDto
            {
                Email = request.Email,
                Password = request.Password,
                RememberMe = request.RememberMe
            };
        }
    }
}
