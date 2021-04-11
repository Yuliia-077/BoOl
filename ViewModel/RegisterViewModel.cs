﻿using BoOl.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введіть електронну пошту")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Оберіть співробітника")]
        public int WorkerId { get; set; }

        public Worker Worker { get; set; } 

        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Підтвердіть пароль")]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
