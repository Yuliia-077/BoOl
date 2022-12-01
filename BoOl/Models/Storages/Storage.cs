using BoOl.Application.Models.Storages;
using System;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models.Storages
{
    public class Storage
    {
        public int? Id { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть назву!")]
        public string Name { get; set; }
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть виробника!")]
        public string Manufacturer { get; set; }
        [Required(ErrorMessage = "Введіть виробника!")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Введіть закупівельну ціну!")]
        public double PurchasePrice { get; set; }
        [Required(ErrorMessage = "Введіть оптову ціну!")]
        public double WholesalePrice { get; set; }
        [Required(ErrorMessage = "Введіть роздрібну ціну!")]
        public double RetailPrice { get; set; }
        [Required(ErrorMessage = "Оберіть дату і час прибуття!")]
        public DateTime DateOfArrival { get; set; }
        [Required(ErrorMessage = "Оберіть модель!")]
        public int ModelId { get; set; }

        public int WorkerId { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static Storage AsViewModel(this StorageDto dto)
        {
            return new Storage
            {
                Id = dto.Id,
                Name = dto.Name,
                Manufacturer = dto.Manufacturer,
                Quantity = dto.Quantity,
                PurchasePrice = dto.PurchasePrice,
                WholesalePrice = dto.WholesalePrice,
                RetailPrice = dto.RetailPrice,
                DateOfArrival = dto.DateOfArrival,
                ModelId = dto.ModelId,
                WorkerId = dto.WorkerId
            };
        }

        public static StorageDto AsDto(this Storage request)
        {
            return new StorageDto
            {
                Id = request.Id,
                Name = request.Name,
                Manufacturer = request.Manufacturer,
                Quantity = request.Quantity,
                PurchasePrice = request.PurchasePrice,
                WholesalePrice = request.WholesalePrice,
                RetailPrice = request.RetailPrice,
                DateOfArrival = request.DateOfArrival,
                ModelId = request.ModelId,
                WorkerId = request.WorkerId
            };
        }
    }
}
