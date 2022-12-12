using BoOl.Application.Models.Parts;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models.Parts
{
    public class Part
    {
        public int? Id { get; set; }
        public bool IsInjured { get; set; }

        [Required(ErrorMessage = "Введіть серійний номер!")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "Оберіть склад!")]
        public int StorageId { get; set; }

        public int CustomServiceId { get; set; }

        public string StorageName { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static PartDto AsDto(this Part request)
        {
            return new PartDto
            {
                Id = request.Id,
                IsInjured = request.IsInjured,
                SerialNumber = request.SerialNumber,
                StorageId = request.StorageId,
                CustomServiceId = request.CustomServiceId
            };
        }

        public static Part AsViewModel(this PartDto dto)
        {
            return new Part
            {
                Id = dto.Id,
                IsInjured = dto.IsInjured,
                SerialNumber = dto.SerialNumber,
                StorageId = dto.StorageId,
                CustomServiceId = dto.CustomServiceId,
                StorageName = dto.StorageName
            };
        }
    }
}
