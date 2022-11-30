using System;

namespace BoOl.Application.Models.Storages
{
    public class StorageDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public int Quantity { get; set; }

        public double PurchasePrice { get; set; }

        public double WholesalePrice { get; set; }

        public double RetailPrice { get; set; }

        public DateTime DateOfArrival { get; set; }

        public int ModelId { get; set; }

        public int WorkerId { get; set; }
    }
}
