using BoOl.Application.Models.Orders;
using System;
using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.Date)]
        public DateTime DateOfAdmission { get; set; }
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
                ProductModel = dto.ProductModel,
                DateOfAdmission = dto.DateOfAdmission
            };
        }
    }
}
