using System;

namespace BoOl.Application.Models.Storages
{
    public class StorageListItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public double RetailPrice { get; set; }

        public string ModelManufacturer { get; set; }

        public string ModelType { get; set; }

        public DateTime DateOfArrival { get; set; }
    }
}
