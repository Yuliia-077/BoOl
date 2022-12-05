using BoOl.Application.Models.Parts;
using BoOl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface IPartRepository: IBaseRepository
    {
        Task<bool> ExistWithStorageId(int serviceId);
        Task<IList<PartDto>> GetListAsync(int customServiceId, int currentPage, int pageSize);
        Task<Part> Get(int id);
        Task DeleteAsync(int id);
        Task AddAsync(Part item);
        Task<int> Count(int customServiceId);
        Task<int> GetStorageId(int id);
    }
}
