using System;
using System.Collections.Generic;

namespace BoOl.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public bool Payment { get; set; }
        public double? Discount { get; set; }

        public string Status { get; set; }

        public DateTime DateOfAdmission { get; set; }
        public DateTime? DateOfIssue { get; set; }

        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public List<CustomService> CustomServices { get; set; }
    }
}
