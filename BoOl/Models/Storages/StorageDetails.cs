using BoOl.Application.Models.Storages;
using System;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models.Storages
{
    public class StorageDetails
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public int Quantity { get; set; }

        public double PurchasePrice { get; set; }

        public double WholesalePrice { get; set; }

        public double RetailPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfArrival { get; set; }

        public int ModelId { get; set; }

        public int WorkerId { get; set; }

        public string Model { get; set; }

        public string WorkerName { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static StorageDetails AsViewModel(this StorageDetailsDto dto)
        {
            return new StorageDetails
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
                Model = dto.Model,
                WorkerId = dto.WorkerId,
                WorkerName = dto.WorkerName
            };
        }
    }
}
