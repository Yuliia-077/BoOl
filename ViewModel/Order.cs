using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models
{
    public class Order
    {
        public int Id { get; set; }
        public bool Payment { get; set; }
        public double? Discount { get; set; }

        [Required(ErrorMessage = "Оберіть статус!")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Введіть дату!")]
        public DateTime DateOfAdmission { get; set; }
        public DateTime? DateOfIssue { get; set; }

        [Required(ErrorMessage = "Оберіть працівника!")]
        public Worker Worker { get; set; }

        [Required(ErrorMessage = "Оберіть техніку!")]
        public Product Product { get; set; }
    }
}
