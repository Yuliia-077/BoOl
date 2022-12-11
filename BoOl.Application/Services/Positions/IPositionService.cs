using BoOl.Application.Models;
using BoOl.Application.Models.Positions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Positions
{
    public interface IPositionService
    {
        Task<IList<PositionListItemDto>> GetListAsync(string filter, bool isActive);

        Task<PositionDto> GetById(int id);

        Task Delete(int id);

        Task<int> Create(PositionDto dto);

        Task Update(PositionDto dto);

        Task<IList<SelectListItem>> SelectListOfPositionsAsync();
    }
}
