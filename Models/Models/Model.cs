using BoOl.Application.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models.Models
{
    public class Model
    {
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть виробника!")]
        public string Manufacturer { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть модель!")]
        public string Type { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static ModelDto AsDto(this Model request)
        {
            return new ModelDto
            {
                Id = request.Id,
                Manufacturer = request.Manufacturer,
                Type = request.Type
            };
        }

        public static Model AsViewModel(this ModelDto dto)
        {
            return new Model
            {
                Id = dto.Id,
                Manufacturer = dto.Manufacturer,
                Type = dto.Type
            };
        }
    }
}
