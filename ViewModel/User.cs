using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введіть електронну пошту!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введіть пароль!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Оберіть працівника!")]
        public Worker Worker { get; set; }

    }
}
