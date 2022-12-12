using BoOl.Application.Models.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введіть електронну пошту!")]
        [EmailAddress(ErrorMessage = "Не коректна електронні пошта.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Оберіть співробітника!")]
        public int WorkerId { get; set; }

        [Required(ErrorMessage = "Введіть пароль!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Підтвердіть пароль!")]
        [Compare("Password", ErrorMessage = "Паролі не співпадають!")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        public IList<string> UserRoles { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static RegisterDto AsDto(this RegisterViewModel request)
        {
            return new RegisterDto
            {
                Email = request.Email,
                Password = request.Password,
                WorkerId = request.WorkerId,
                UserRoles = request.UserRoles
            };
        }
    }
}
