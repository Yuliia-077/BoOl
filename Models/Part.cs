using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Models
{
    public class Part
    {
        public int Id { get; set; }
        
        public string SerialNumber { get; set; }

        public int StorageId { get; set; }

        public Storage Storage { get; set; }

        public CustomService CustomService { get; set; }
    }
}
