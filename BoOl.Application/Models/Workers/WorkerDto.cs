using System;

namespace BoOl.Application.Models.Workers
{
    public class WorkerDto
    {
        public int? Id { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Education { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime? DateOfQuit { get; set; }
        public int PositionId { get; set; }
    }
}
