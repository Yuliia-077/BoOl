using BoOl.Application.Models;
using BoOl.Application.Models.Storages;
using BoOl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface IStorageRepository : IBaseRepository
    {
        Task<IList<StorageListItemDto>> GetListAsync(int currentPage, int pageSize, string searchString);
        Task<StorageDto> GetByIdAsync(int id);
        Task<Storage> Get(int id);
        Task AddAsync(Storage t);
        Task DeleteAsync(int id);
        Task<int> CountAsync(string searchString);
        Task<bool> ExistItemsWithModelsInStorage(int modelId);
        Task<IEnumerable<SelectedModel>> SelectAsync();
    }
}
