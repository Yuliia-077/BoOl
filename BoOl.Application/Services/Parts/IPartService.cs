using BoOl.Application.Models.Parts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Parts
{
    public interface IPartService
    {
        Task<IList<PartDto>> GetListAsync(int customServiceId, int currentPage, int pageSize);

        Task<int> Count(int customServiceId);

        Task Delete(int id);

        Task DeleteWithReturnToStorage(int id);

        Task<int> Create(PartDto dto);
    }
}
