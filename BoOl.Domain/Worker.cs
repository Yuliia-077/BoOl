using System;
using System.Collections.Generic;

namespace BoOl.Domain
{
    public class Worker
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

        //public string UserId { get; set; }
        public User User { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }

        public List<Order> Orders { get; set; }
        public List<Storage> Storages { get; set; }
        public List<CustomService> CustomServices { get; set; }
    }
}
