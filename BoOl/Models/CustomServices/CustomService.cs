using BoOl.Application.Models.CustomServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models.CustomServices
{
    public class CustomService
    {
        public int Id { get; set; }
        public bool IsDone { get; set; }
        [Required(ErrorMessage = "Введіть дату виконання!")]
        [DataType(DataType.Date)]
        public DateTime ExecutionDate { get; set; }
        [Required(ErrorMessage = "Оберіть послугу!")]
        public int ServiceId { get; set; }
        public int OrderId { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static CustomService AsViewModel(this CustomServiceDto dto)
        {
            return new CustomService
            {
                Id = dto.Id,
                IsDone = dto.IsDone,
                ExecutionDate = dto.ExecutionDate,
                ServiceId = dto.ServiceId,
                OrderId = dto.OrderId
            };
        }

        public static CustomServiceDto AsDto(this CustomService request)
        {
            return new CustomServiceDto
            {

                Id = request.Id,
                IsDone = request.IsDone,
                ExecutionDate = request.ExecutionDate,
                ServiceId = request.ServiceId,
                OrderId = request.OrderId
            };
        }
    }
}

