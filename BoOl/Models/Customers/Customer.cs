using BoOl.Application.Models.Customers;
using System;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models.Customers
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть прізвище!")]
        public string LastName { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть ім'я!")]
        public string FirstName { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть по-батькові!")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Введіть номер телефону!")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Введіть дату народження!")]
        public DateTime DateOfBirth { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть адресу!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Введіть електронну пошту!")]
        [EmailAddress]
        public string Email { get; set; }

        public double? Discount { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static CustomerDto AsDto(this Customer request)
        {
            return new CustomerDto
            {
                Id = request.Id,
                LastName = request.LastName,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                PhoneNumber = request.PhoneNumber,
                DateOfBirth = request.DateOfBirth,
                Address = request.Address,
                Email = request.Email,
                Discount = request.Discount
            };
        }

        public static Customer AsViewModel(this CustomerDto dto)
        {
            return new Customer
            {
                Id = dto.Id,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                PhoneNumber = dto.PhoneNumber,
                DateOfBirth = dto.DateOfBirth,
                Address = dto.Address,
                Email = dto.Email,
                Discount = dto.Discount
            };
        }
    }
}
