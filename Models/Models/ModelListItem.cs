using BoOl.Application.Models.Models;

namespace BoOl.Models.Models
{
    public class ModelListItem
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static ModelListItem AsViewModel(this ModelListItemDto dto)
        {
            return new ModelListItem
            {
                Id = dto.Id,
                Manufacturer = dto.Manufacturer,
                Type = dto.Type
            };
        }
    }
}
