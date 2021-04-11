using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models
{
    public class Worker
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

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть освіту!")]
        public string Education { get; set; }

        [Required(ErrorMessage = "Введіть дату прийому на роботу!")]
        public DateTime DateOfEmployment { get; set; }

        public DateTime? DateOfQuit { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }

        public List<Order> Orders { get; set; }
        public List<Storage> Storages { get; set; }
        public List<CustomService> CustomServices { get; set; }
    }
}
