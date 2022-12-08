using BoOl.Application.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models.Products
{
    public class Product
    {
        public int? Id { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Довжина рядка повинна бути від 5 символів!")]
        [Required(ErrorMessage = "Введіть серійний номер!")]
        public string SerialNumber { get; set; }

        public string AdditionalInf { get; set; }

        [Required(ErrorMessage = "Оберіть модель!")]
        public int ModelId { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

    }

    public static partial class ViewModelMapperExtensions
    {
        public static ProductDto AsDto(this Product request)
        {
            return new ProductDto
            {
                Id = request.Id,
                SerialNumber = request.SerialNumber,
                AdditionalInf = request.AdditionalInf,
                ModelId = request.ModelId,
                CustomerId = request.CustomerId,
                CustomerName = request.CustomerName
            };
        }

        public static Product AsViewModel(this ProductDto dto)
        {
            return new Product
            {
                Id = dto.Id,
                SerialNumber = dto.SerialNumber,
                AdditionalInf = dto.AdditionalInf,
                ModelId = dto.ModelId,
                CustomerId = dto.CustomerId,
                CustomerName = dto.CustomerName
            };
        }
    }
}
