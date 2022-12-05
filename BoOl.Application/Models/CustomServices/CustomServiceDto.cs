using System;

namespace BoOl.Application.Models.CustomServices
{
    public class CustomServiceDto
    {
        public int Id { get; set; }
        public bool IsDone { get; set; }
        public DateTime ExecutionDate { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
    }
}
