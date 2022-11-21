using BoOl.Application.Models.Storages;

namespace BoOl.Models.Storages
{
    public class StorageListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public double RetailPrice { get; set; }

        public string ModelManufacturer { get; set; }

        public string ModelType { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static StorageListItem AsViewModel(this StorageListItemDto dto)
        {
            return new StorageListItem
            {
                Id = dto.Id,
                Name = dto.Name,
                Quantity = dto.Quantity,
                RetailPrice = dto.RetailPrice,
                ModelManufacturer = dto.ModelManufacturer,
                ModelType = dto.ModelType
            };
        }
    }
}
