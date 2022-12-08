using System;

namespace BoOl.Application.Models.Orders
{
    public class OrderListItemDto
    {
        public int Id { get; set; }
        public bool Payment { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string ProductModel { get; set; }
        public DateTime DateOfAdmission { get; set; }
    }
}
