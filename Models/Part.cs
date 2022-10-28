using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Models
{
    public class Part
    {
        public int Id { get; set; }
        public bool IsInjured { get; set; }

        [Required(ErrorMessage = "Введіть серійний номер!")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "Оберіть склад!")]
        public int StorageId { get; set; }
        public Storage Storage { get; set; }

        public int CustomServiceId { get; set; }
        public CustomService CustomService { get; set; }
    }
}
