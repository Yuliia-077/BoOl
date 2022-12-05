using BoOl.Application.Models.Orders;
using BoOl.Models.CustomServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BoOl.Models.Orders
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public bool Payment { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string ProductModel { get; set; }
        public string SerialNumber { get; set; }
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfAdmission { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfIssue { get; set; }
        public double TotalPrice { get; set; }
        public double? TotalPriceWithDiscount { get; set; }
        public int CountCustomServices { get; set; }
        public double? Discount { get; set; }
        public IList<CustomServiceListItem> CustomServices { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static OrderDetails AsViewModel(this OrderDetailsDto dto)
        {
            return new OrderDetails
            {
                Id = dto.Id,
                Payment = dto.Payment,
                Status = dto.Status,
                CustomerId = dto.CustomerId,
                CustomerName = dto.CustomerName,
                ProductId = dto.ProductId,
                ProductModel = dto.ProductModel,
                SerialNumber = dto.SerialNumber,
                WorkerId = dto.WorkerId,
                WorkerName = dto.WorkerName,
                DateOfAdmission = dto.DateOfAdmission,
                DateOfIssue = dto.DateOfIssue,
                TotalPrice = dto.TotalPrice,
                TotalPriceWithDiscount = dto.Discount != null ? (dto.TotalPrice * ((100 - dto.Discount) / 100)) : null,
                CountCustomServices = dto.CountCustomServices,
                Discount = dto.Discount,
                CustomServices = dto.CustomServices.Select(x => x.AsViewModel()).ToList()
            };
        }
    }
}
