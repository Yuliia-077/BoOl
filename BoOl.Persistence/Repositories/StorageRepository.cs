using BoOl.Application.Interfaces;
using BoOl.Application.Models;
using BoOl.Application.Models.Storages;
using BoOl.Domain;
using BoOl.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Persistence.Repositories
{
    //отримання даних з бд по таблиці Storage
    public class StorageRepository: BaseRepository, IStorageRepository
    {
        public StorageRepository(IOptions<DatabaseOptions> databaseOptions, BoOlContext context) : base(databaseOptions, context) { }

        
        public async Task AddAsync(Storage item)
        {
            await Create<Storage>(item);
        }
      
        public async Task DeleteAsync(int id)
        {
            var Storage = await Get(id);
            if(Storage != null)
            {
                DbContext.Storages.Remove(Storage);
            }
        }
        
        public async Task<IList<StorageListItemDto>> GetListAsync(int currentPage, int pageSize, string searchString, int? workerId = null)
        {
            return await DbContext.Storages
                .Include(s => s.Model)
                .Where(s => (string.IsNullOrEmpty(searchString) 
                            || s.Name.Contains(searchString)
                            || s.Model.Manufacturer.Contains(searchString)
                            || s.Model.Type.Contains(searchString))
                        && (!workerId.HasValue
                            || s.WorkerId == workerId.Value))
                .OrderByDescending(x => x.DateOfArrival)
                .ThenBy(c => c.Name)
                .ThenBy(c => c.Model.Manufacturer)
                .ThenBy(c => c.Model.Type)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new StorageListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ModelManufacturer = x.Model.Manufacturer,
                    ModelType = x.Model.Type,
                    Quantity = x.Quantity,
                    RetailPrice = x.RetailPrice,
                    DateOfArrival = x.DateOfArrival
                })
                .ToListAsync();
        }

        public async Task<StorageDetailsDto> GetDetailsAsync(int id)
        {
            var item = await DbContext.Storages
                .Include(x => x.Model)
                .Include(x => x.Worker)
                .SingleOrDefaultAsync(x => x.Id == id);

            if(item == null)
            {
                return null;
            }

            return new StorageDetailsDto
            {
                Id = item.Id,
                Manufacturer = item.Manufacturer,
                Model = item.Model.Manufacturer + " " + item.Model.Type,
                ModelId = item.ModelId,
                DateOfArrival = item.DateOfArrival,
                Name = item.Name,
                PurchasePrice = item.PurchasePrice,
                Quantity = item.Quantity,
                WholesalePrice = item.WholesalePrice,
                RetailPrice = item.RetailPrice,
                WorkerId = item.WorkerId,
                WorkerName = item.Worker.LastName + " " + item.Worker.FirstName
            };
        }

        public Task<Storage> Get(int id)
        {
            return Get<Storage>(id);
        }

        public async Task<int> CountAsync(string searchString, int? workerId = null)
        {
            return await DbContext.Storages
                .Include(s => s.Model)
                .Where(s => (string.IsNullOrEmpty(searchString)
                            || s.Name.Contains(searchString)
                            || s.Model.Manufacturer.Contains(searchString)
                            || s.Model.Type.Contains(searchString))
                        && (!workerId.HasValue
                            || s.WorkerId == workerId.Value))
                .CountAsync();
        }

        public async Task<bool> ExistItemsWithModelsInStorage(int modelId)
        {
            return await DbContext.Storages.AnyAsync(x => x.ModelId == modelId);
        }
        
        public async Task<bool> ExistForWorkerId(int workerId)
        {
            return await DbContext.Storages.AnyAsync(x => x.WorkerId == workerId);
        }

        public async Task<bool> Exist(int id)
        {
            return await DbContext.Storages.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> IsUnique(StorageDto dto)
        {
            return await DbContext.Storages.AnyAsync(x => x.Id != dto.Id 
                                                        && x.Manufacturer == dto.Manufacturer 
                                                        && x.ModelId == dto.ModelId 
                                                        && x.Name == dto.Name 
                                                        && x.DateOfArrival == dto.DateOfArrival);
        }

        public async Task<StorageDto> GetByIdAsync(int id)
        {
            var item = await DbContext.Storages
                .SingleOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                return null;
            }

            return new StorageDto
            {
                Id = item.Id,
                Manufacturer = item.Manufacturer,
                ModelId = item.ModelId,
                DateOfArrival = item.DateOfArrival,
                Name = item.Name,
                PurchasePrice = item.PurchasePrice,
                Quantity = item.Quantity,
                WholesalePrice = item.WholesalePrice,
                RetailPrice = item.RetailPrice,
                WorkerId = item.WorkerId
            };
        }

        public async Task<IList<SelectListItem>> SelectAsync()
        {
            return await DbContext.Storages
                .Where(s => s.Quantity >= 1)
                .Select(x => new SelectListItem{ 
                   Value = x.Id, 
                   Text = x.Name + " " + x.Model.Manufacturer + " " + x.Model.Type })
                .ToListAsync();
        }
    }
}
