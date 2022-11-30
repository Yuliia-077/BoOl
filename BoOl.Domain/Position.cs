using System.Collections.Generic;

namespace BoOl.Domain
{
    public class Position
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Salary { get; set; }

        public double PercentageOfWork { get; set; }

        public List<Worker> Workers { get; set; }
    }
}
