using BoOl.Application.Models.Products;
using BoOl.Models.Orders;
using System.Collections.Generic;
using System.Linq;

namespace BoOl.Models.Products
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string AdditionalInf { get; set; }
        public int ModelId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public IList<OrderListItem> Orders { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static ProductDetails AsViewModel(this ProductDetailsDto dto)
        {
            return new ProductDetails
            {
                Id = dto.Id,
                SerialNumber = dto.SerialNumber,
                Model = dto.Model,
                AdditionalInf = dto.AdditionalInf,
                ModelId = dto.ModelId,
                CustomerId = dto.CustomerId,
                CustomerName = dto.CustomerName,
                Orders = dto.Orders.Select(x => x.AsViewModel()).ToList()
            };
        }
    }
}
