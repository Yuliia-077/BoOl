using BoOl.Application.Models.Services;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models.Services
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

    public static partial class ViewModelMapperExtensions
    {
        public static ServiceDto AsDto(this Service request)
        {
            return new ServiceDto
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price
            };
        }

        public static Service AsViewModel(this ServiceDto dto)
        {
            return new Service
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price
            };
        }
    }
}
