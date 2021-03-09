using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models
{
    public class Position
    {
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть назву посади!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введіть зарплату!")]
        public double Salary { get; set; }

        public double PercentageOfWork { get; set; }

        public List<Worker> Workers { get; set; }
    }
}
