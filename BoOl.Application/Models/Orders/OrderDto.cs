using System;

namespace BoOl.Application.Models.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }
        public bool Payment { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public double? Discount { get; set; }
        public int ProductId { get; set; }
        public int WorkerId { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public DateTime? DateOfIssue { get; set; }
    }
}
