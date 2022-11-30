using BoOl.Application.Models.Services;

namespace BoOl.Models.Services
{
    public class ServiceListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static ServiceListItem AsViewService(this ServiceListItemDto dto)
        {
            return new ServiceListItem
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price
            };
        }
    }
}
