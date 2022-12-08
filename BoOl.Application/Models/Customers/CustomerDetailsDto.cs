using BoOl.Application.Models.Orders;
using BoOl.Application.Models.Products;
using System;
using System.Collections.Generic;

namespace BoOl.Application.Models.Customers
{
    public class CustomerDetailsDto
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public double? Discount { get; set; }

        public int CountOfProducts { get; set; }

        public int CountOfOrders { get; set; }

        public IList<ProductListItemDto> Products { get; set; }

        public IList<OrderListItemDto> Orders { get; set; }

    }
}
