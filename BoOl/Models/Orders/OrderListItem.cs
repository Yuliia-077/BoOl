using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BoOl.Application.Models.Orders;

namespace BoOl.Models.Orders
{
    public class OrderListItem
    {
        public int Id { get; set; }
        public bool Payment { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string ProductModel { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static OrderListItem AsViewModel(this OrderListItemDto dto)
        {
            return new OrderListItem
            {
                Id = dto.Id,
                Payment = dto.Payment,
                Status = dto.Status,
                CustomerId = dto.CustomerId,
                CustomerName = dto.CustomerName,
                ProductId = dto.ProductId,
                ProductModel = dto.ProductModel
            };
        }
    }
}
