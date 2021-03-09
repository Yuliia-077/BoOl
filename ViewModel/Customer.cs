using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть прізвище!")]
        public string LastName { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть ім'я!")]
        public string FirstName { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть по-батькові!")]
        public string MiddleName { get; set; }

        [StringLength(13, MinimumLength = 13, ErrorMessage = "Довжина рядка повинна бути 13 символів!")]
        [Required(ErrorMessage = "Введіть номер телефону!")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Введіть дату народження!")]
        public DateTime DateOfBirth { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть адресу!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Введіть електронну пошту!")]
        [EmailAddress]
        public string Email { get; set; }

        public double? Discount { get; set; }


    }
}
