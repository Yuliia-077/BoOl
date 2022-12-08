using BoOl.Application.Models.Products;

namespace BoOl.Models.Products
{
    public class ProductListItem
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static ProductListItem AsViewModel(this ProductListItemDto dto)
        {
            return new ProductListItem
            {
                Id = dto.Id,
                SerialNumber = dto.SerialNumber,
                Model = dto.Model
            };
        }
    }
}
