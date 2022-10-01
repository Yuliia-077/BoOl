using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BoOl.RequestModels
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Довжина рядка повинна бути від 5 символів!")]
        [Required(ErrorMessage = "Введіть серійний номер!")]
        public string SerialNumber { get; set; }

        public string AdditionalInf { get; set; }

        [Required(ErrorMessage = "Оберіть модель!")]
        public int ModelId { get; set; }

        public Model Model { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<Order> Orders { get; set; }

    }
}
