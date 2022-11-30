using System.Collections.Generic;

namespace BoOl.Domain
{
    public class Model
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Type { get; set; }

        public List<Product> Products { get; set; }

        public List<Storage> Storages { get; set; }
    }
}
