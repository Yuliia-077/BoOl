using BoOl.Application.Models;
using BoOl.Application.Models.Positions;
using BoOl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface IPositionRepository : IBaseRepository
    {
        Task<bool> Exist(int id);
        Task<bool> ExistByName(string name, int? id = null);
        Task<IList<PositionListItemDto>> GetListAsync(string filter, bool isActive);
        Task<PositionDto> GetById(int id);
        Task<Position> Get(int id);
        Task<IList<SelectListItem>> SelectAsync();
        Task DeleteAsync(int id);
        Task AddAsync(Position item);
    }
}
