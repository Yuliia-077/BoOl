using System;
using System.Collections.Generic;

namespace BoOl.Domain
{
    public class CustomService
    {
        public int Id { get; set; }
        public bool IsDone { get; set; }

        public double Price { get; set; }

        public DateTime ExecutionDate { get; set; }

        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public List<Part> Parts { get; set; }

    }
}
