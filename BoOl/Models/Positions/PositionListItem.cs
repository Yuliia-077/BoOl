using BoOl.Application.Models.Positions;
using BoOl.Models.Workers;
using System.Collections.Generic;
using System.Linq;

namespace BoOl.Models.Positions
{
    public class PositionListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<WorkerListItem> Workers { get; set; }

    }

    public static partial class ViewModelMapperExtensions
    {
        public static PositionListItem AsViewModel(this PositionListItemDto dto)
        {
            return new PositionListItem
            {
                Id = dto.Id,
                Name = dto.Name,
                Workers = dto.Workers.Select(x => x.AsViewModel()).ToList()
            };
        }
    }
}
