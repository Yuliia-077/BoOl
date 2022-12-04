using BoOl.Application.Models.CustomServices;
using System;

namespace BoOl.Models.CustomServices
{
    public class CustomServiceListItem
    {
        public int Id { get; set; }
        public bool IsDone { get; set; }
        public DateTime ExecutionDate { get; set; }
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static CustomServiceListItem AsViewModel(this CustomServiceListItemDto dto)
        {
            return new CustomServiceListItem
            {
                Id = dto.Id,
                IsDone = dto.IsDone,
                ExecutionDate = dto.ExecutionDate,
                WorkerId = dto.WorkerId,
                WorkerName = dto.WorkerName,
                ServiceId = dto.ServiceId,
                ServiceName = dto.ServiceName
            };
        }
    }
}

