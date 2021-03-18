using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Models
{
    public class Storage
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public int Quantity { get; set; }

        public double PurchasePrice { get; set; }

        public double WholesalePrice { get; set; }

        public double RetailPrice { get; set; }

        public DateTime DateOfArrival { get; set; }

        public int ModelId { get; set; }

        public Model Model { get; set; }

        public int WorkerId { get; set; }

        public Worker Worker { get; set; }

        public List<Part> Parts { get; set; }
    }
}
