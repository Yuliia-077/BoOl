using BoOl.Application.Models.Workers;
using System.Collections.Generic;

namespace BoOl.Application.Models.Positions
{
    public class PositionListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<WorkerListItemDto> Workers { get; set; }
    }
}
