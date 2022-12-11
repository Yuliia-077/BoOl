using BoOl.Application.Models.Positions;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models.Positions
{
    public class Position
    {
        public int? Id { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть назву посади!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введіть зарплату!")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "Введіть відсоток від роботи!")]
        [Range(0, 100, ErrorMessage = "Відсоток від роботи має бути в діапазоні від 0 до 100.")]
        public double PercentageOfWork { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static PositionDto AsDto(this Position request)
        {
            return new PositionDto
            {
                Id = request.Id,
                Name = request.Name,
                Salary = request.Salary,
                PercentageOfWork = request.PercentageOfWork
            };
        }

        public static Position AsViewModel(this PositionDto dto)
        {
            return new Position
            {
                Id = dto.Id,
                Name = dto.Name,
                Salary = dto.Salary,
                PercentageOfWork = dto.PercentageOfWork
            };
        }
    }
}
