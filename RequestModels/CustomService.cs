using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.RequestModels
{
    public class CustomService
    {
        public int Id { get; set; }
        public bool IsDone { get; set; }

        [Required(ErrorMessage = "Введіть ціну!")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Введіть дату виконання!")]
        public DateTime ExecutionDate { get; set; }

        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        [Required(ErrorMessage = "Оберіть послугу!")]
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public List<Part> Parts { get; set; }

    }
}

