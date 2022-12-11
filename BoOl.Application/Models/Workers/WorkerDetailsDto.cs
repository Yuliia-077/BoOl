using BoOl.Application.Models.CustomServices;
using BoOl.Application.Models.Orders;
using BoOl.Application.Models.Storages;
using System;
using System.Collections.Generic;

namespace BoOl.Application.Models.Workers
{
    public class WorkerDetailsDto
    {
        public int Id { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Education { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime? DateOfQuit { get; set; }
        public bool IsActive { get; set; }
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public double Salary { get; set; }
        public double PercentageOfWork { get; set; }
        public string Email { get; set; }

        public int CountOfOrders { get; set; }
        public IList<OrderListItemDto> Orders { get; set; }
        public int CountOfStorages { get; set; }
        public IList<StorageListItemDto> Storages { get; set; }
        public int CountOfCustomServices { get; set; }
        public IList<CustomServiceListItemDto> CustomServices { get; set; }
    }
}
