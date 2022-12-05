using BoOl.Application.Models.CustomServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models.CustomServices
{
    public class CustomServiceDetails
    {
        public int Id { get; set; }
        public bool IsDone { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExecutionDate { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int OrderId { get; set; }
        public double Price { get; set; }
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static CustomServiceDetails AsViewModel(this CustomServiceDetailsDto dto)
        {
            return new CustomServiceDetails
            {
                Id = dto.Id,
                IsDone = dto.IsDone,
                ExecutionDate = dto.ExecutionDate,
                ServiceId = dto.ServiceId,
                OrderId = dto.OrderId,
                ServiceName = dto.ServiceName,
                Price = dto.Price,
                WorkerId = dto.WorkerId,
                WorkerName = dto.WorkerName
            };
        }
    }
}

