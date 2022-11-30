using System.Collections.Generic;

namespace BoOl.Domain
{
    public class Product
    {
        public int Id { get; set; }

        public string SerialNumber { get; set; }

        public string AdditionalInf { get; set; }

        public int ModelId { get; set; }

        public Model Model { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<Order> Orders { get; set; }

    }
}
