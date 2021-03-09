using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models
{
    public class Service
    {
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть назву!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введіть ціну!")]
        public double Price { get; set; }
    }
}
