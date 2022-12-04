using BoOl.Application.Models.CustomServices;
using System;
using System.Collections.Generic;

namespace BoOl.Application.Models.Orders
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }
        public bool Payment { get; set; }
        public string Status { get; set; }
        public double? Discount { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string SerialNumber { get; set; }
        public string ProductModel { get; set; }
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public double TotalPrice { get; set; }
        public double? TotalPriceWithDiscount { get; set; }
        public int CountCustomServices { get; set; }
        public IList<CustomServiceListItemDto> CustomServices { get; set; }
    }
}
