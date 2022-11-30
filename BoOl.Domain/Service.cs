using System.Collections.Generic;

namespace BoOl.Domain
{
    public class Service
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public List<CustomService> CustomServices { get; set; }
    }
}
