using BoOl.Application.Models.Orders;
using System.Collections.Generic;

namespace BoOl.Application.Models.Products
{
    public class ProductDetailsDto
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string AdditionalInf { get; set; }
        public int ModelId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CountOfOrders { get; set; }
        public IList<OrderListItemDto> Orders { get; set; }
    }
}
