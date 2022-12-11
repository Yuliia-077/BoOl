using BoOl.Application.Models.Workers;
using System;
using System.ComponentModel.DataAnnotations;

namespace BoOl.Models.Workers
{
    public class Worker
    {
        public int? Id { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть прізвище!")]
        public string LastName { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть ім'я!")]
        public string FirstName { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть по-батькові!")]
        public string MiddleName { get; set; }

        [StringLength(13, MinimumLength = 13, ErrorMessage = "Довжина рядка повинна бути 13 символів!")]
        [Required(ErrorMessage = "Введіть номер телефону!")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Введіть дату народження!")]
        public DateTime DateOfBirth { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть адресу!")]
        public string Address { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина рядка повинна бути від 3 символів!")]
        [Required(ErrorMessage = "Введіть освіту!")]
        public string Education { get; set; }

        [Required(ErrorMessage = "Введіть дату прийому на роботу!")]
        public DateTime DateOfEmployment { get; set; }

        public DateTime? DateOfQuit { get; set; }

        [Required(ErrorMessage = "Оберіть посаду!")]
        public int PositionId { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static WorkerDto AsDto(this Worker request)
        {
            return new WorkerDto
            {
                Id = request.Id,
                LastName = request.LastName,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                PhoneNumber = request.PhoneNumber,
                DateOfBirth = request.DateOfBirth,
                Address = request.Address,
                Education = request.Education,
                DateOfEmployment = request.DateOfEmployment,
                DateOfQuit = request.DateOfQuit,
                PositionId = request.PositionId
            };
        }

        public static Worker AsViewModel(this WorkerDto dto)
        {
            return new Worker
            {
                Id = dto.Id,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                PhoneNumber = dto.PhoneNumber,
                DateOfBirth = dto.DateOfBirth,
                Address = dto.Address,
                Education = dto.Education,
                DateOfEmployment = dto.DateOfEmployment,
                DateOfQuit = dto.DateOfQuit,
                PositionId = dto.PositionId
            };
        }
    }
}
