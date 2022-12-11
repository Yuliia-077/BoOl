using BoOl.Application.Models.Workers;

namespace BoOl.Models.Workers
{
    public class WorkerListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static WorkerListItem AsViewModel(this WorkerListItemDto dto)
        {
            return new WorkerListItem
            {
                Id = dto.Id,
                Name = dto.Name,
                PhoneNumber = dto.NumberPhone
            };
        }
    }
}
