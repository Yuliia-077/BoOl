﻿using BoOl.Application.Models;
using BoOl.Application.Models.Storages;
using BoOl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface IStorageRepository : IBaseRepository
    {
        Task<IList<StorageListItemDto>> GetListAsync(int currentPage, int pageSize, string searchString, int? workerId = null);
        Task<StorageDto> GetByIdAsync(int id);
        Task<StorageDetailsDto> GetDetailsAsync(int id);
        Task<Storage> Get(int id);
        Task<int> GetModuleId(int id);
        Task AddAsync(Storage t);
        Task DeleteAsync(int id);
        Task<int> CountAsync(string searchString, int? workerId = null);
        Task<bool> ExistItemsWithModelsInStorage(int modelId);
        Task<bool> ExistForWorkerId(int workerId);
        Task<bool> Exist(int id);
        Task<bool> IsUnique(StorageDto dto);
        Task<IList<SelectListItem>> SelectAsync();
    }
}
