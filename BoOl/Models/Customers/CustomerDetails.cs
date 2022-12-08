using BoOl.Application.Models.Customers;
using BoOl.Models.Orders;
using BoOl.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BoOl.Models.Customers
{
    public class CustomerDetails
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public double? Discount { get; set; }

        public IList<ProductListItem> Products { get; set; }

        public IList<OrderListItem> Orders { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static CustomerDetails AsViewModel(this CustomerDetailsDto dto)
        {
            return new CustomerDetails
            {
                Id = dto.Id,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                PhoneNumber = dto.PhoneNumber,
                DateOfBirth = dto.DateOfBirth,
                Address = dto.Address,
                Email = dto.Email,
                Discount = dto.Discount,
                Products = dto.Products.Select(x => x.AsViewModel()).ToList(),
                Orders = dto.Orders.Select(x => x.AsViewModel()).ToList()
            };
        }
    }
}
