using BoOl.Application.Models.Storages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Storages
{
    public interface IStorageService
    {
        Task<IList<StorageListItemDto>> GetListItems(int currentPage, int pageSize, string searchString);
        Task<StorageDto> GetById(int id);
        Task<int> Count(string searchString);
        Task<int> Create(StorageDto dto);
        Task Update(StorageDto dto);
    }
}
