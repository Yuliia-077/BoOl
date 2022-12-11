using BoOl.Application.Models.Workers;
using BoOl.Models.CustomServices;
using BoOl.Models.Orders;
using BoOl.Models.Products;
using BoOl.Models.Storages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BoOl.Models.Workers
{
    public class WorkerDetails
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Education { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfEmployment { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfQuit { get; set; }
        public bool IsActive { get; set; }
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public double Salary { get; set; }
        public double PercentageOfWork { get; set; }
        public string Email { get; set; }

        public int CountOfOrders { get; set; }
        public IList<OrderListItem> Orders { get; set; }
        public int CountOfStorages { get; set; }
        public IList<StorageListItem> Storages { get; set; }
        public int CountOfCustomServices { get; set; }
        public IList<CustomServiceListItem> CustomServices { get; set; }
    }

    public static partial class ViewModelMapperExtensions
    {
        public static WorkerDetails AsViewModel(this WorkerDetailsDto dto)
        {
            return new WorkerDetails
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
                IsActive = dto.IsActive,
                PositionId = dto.PositionId,
                PositionName = dto.PositionName,
                Salary = dto.Salary,
                PercentageOfWork = dto.PercentageOfWork,
                Email = dto.Email,
                CountOfOrders = dto.CountOfOrders,
                CountOfCustomServices = dto.CountOfCustomServices,
                CountOfStorages = dto.CountOfStorages,
                Storages = dto.Storages == null ? null : dto.Storages.Select(x => x.AsViewModel()).ToList(),
                Orders = dto.Orders == null ? null : dto.Orders.Select(x => x.AsViewModel()).ToList(),
                CustomServices = dto.CustomServices == null ? null : dto.CustomServices.Select(x => x.AsViewModel()).ToList()
            };
        }
    }
}
