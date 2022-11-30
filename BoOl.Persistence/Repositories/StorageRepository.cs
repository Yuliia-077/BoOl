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
        
        public async Task<IList<StorageListItemDto>> GetListAsync(int currentPage, int pageSize, string searchString)
        {
            return await DbContext.Storages
                .Include(s => s.Model)
                .Where(s => string.IsNullOrEmpty(searchString) 
                    || s.Name.Contains(searchString, System.StringComparison.CurrentCultureIgnoreCase)
                    || s.Model.Manufacturer.Contains(searchString, System.StringComparison.CurrentCultureIgnoreCase)
                    || s.Model.Type.Contains(searchString, System.StringComparison.CurrentCultureIgnoreCase))
                .OrderBy(c => c.Name)
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
                    RetailPrice = x.RetailPrice
                })
                .ToListAsync();
        }

        public async Task<StorageDto> GetByIdAsync(int id)
        {
            var item = await DbContext.Storages.FirstOrDefaultAsync(c => c.Id == id);

            if(item == null)
            {
                return null;
            }

            return new StorageDto
            {
                //Id = item.Id,
                //Name = item.Name,
                //Price = item.Price
            };
        }

        public Task<Storage> Get(int id)
        {
            return Get<Storage>(id);
        }

        public async Task<int> CountAsync(string searchString)
        {
            return await DbContext.Storages
                .Include(s => s.Model)
                .Where(s => string.IsNullOrEmpty(searchString) 
                    || s.Name.Contains(searchString, System.StringComparison.CurrentCultureIgnoreCase) 
                    || s.Model.Manufacturer.Contains(searchString, System.StringComparison.CurrentCultureIgnoreCase) 
                    || s.Model.Type.Contains(searchString, System.StringComparison.CurrentCultureIgnoreCase))
                .CountAsync();
        }

        public async Task<bool> ExistItemsWithModelsInStorage(int modelId)
        {
            return await DbContext.Storages.AnyAsync(x => x.ModelId == modelId);
        }

        public async Task<IEnumerable<SelectedModel>> SelectAsync()
        {
            var deliveryList = await DbContext.Storages.Include(s => s.Model)
                .Where(s => s.Quantity >= 1).Select(
               x => new { Value = x.Id, Text = x.Name + " " + x.Model.Manufacturer + " " + x.Model.Type })
                .ToListAsync();
            List<SelectedModel> models = new List<SelectedModel>();

            foreach (var item in deliveryList)
            {
                models.Add(new SelectedModel(item.Value, item.Text));
            }
            return models;
        }
    }
}
