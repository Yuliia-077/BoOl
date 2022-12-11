using BoOl.Application.Models.Orders;
using System;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public bool Payment { get; set; }

        [Range(0, 100, ErrorMessage = "Знижка має бути в діапазоні від 0 до 100.")]
        public double? Discount { get; set; }

        [Required(ErrorMessage = "Оберіть статус!")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Введіть дату!")]
        [DataType(DataType.Date)]
        public DateTime DateOfAdmission { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfIssue { get; set; }

        [Required(ErrorMessage = "Оберіть працівника!")]
        public int WorkerId { get; set; }

        [Required(ErrorMessage = "Оберіть техніку!")]
        public int ProductId { get; set; }

        public int CustomerId { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static OrderDto AsDto(this Order request)
        {
            return new OrderDto
            {
                Id = request.Id,
                Payment = request.Payment,
                Discount = request.Discount,
                Status = request.Status,
                DateOfAdmission = request.DateOfAdmission,
                DateOfIssue = request.DateOfIssue,
                WorkerId = request.WorkerId,
                CustomerId = request.CustomerId,
                ProductId = request.ProductId
            };
        }

        public static Order AsViewModel(this OrderDto dto)
        {
            return new Order
            {
                Id = dto.Id,
                Payment = dto.Payment,
                Discount = dto.Discount,
                Status = dto.Status,
                DateOfAdmission = dto.DateOfAdmission,
                DateOfIssue = dto.DateOfIssue,
                WorkerId = dto.WorkerId,
                CustomerId = dto.CustomerId,
                ProductId = dto.ProductId
            };
        }
    }
}
