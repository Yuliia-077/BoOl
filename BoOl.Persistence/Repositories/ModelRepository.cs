using BoOl.Application.Interfaces;
using BoOl.Application.Models;
using BoOl.Application.Models.Models;
using BoOl.Domain;
using BoOl.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Persistence.Repositories
{
    //отримання даних з бд по таблиці Model
    public class ModelRepository: BaseRepository, IModelRepository
    {
        public ModelRepository(IOptions<DatabaseOptions> databaseOptions, BoOlContext context) : base(databaseOptions, context) { }

        
        public async Task AddAsync(Model item)
        {
            await Create<Model>(item);
        }
      
        public async Task DeleteAsync(int id)
        {
            var Model = await Get(id);
            if(Model != null)
            {
                DbContext.Models.Remove(Model);
            }
        }
        
        public async Task<IList<ModelListItemDto>> GetListAsync(int currentPage, int pageSize, string searchString)
        {
            return await DbContext.Models
                .Where(s => string.IsNullOrEmpty(searchString) || s.Manufacturer.Contains(searchString) || s.Type.Contains(searchString))
                .OrderBy(c => c.Manufacturer)
                .ThenBy(c => c.Type)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new ModelListItemDto
                {
                    Id = x.Id,
                    Manufacturer = x.Manufacturer,
                    Type = x.Type
                })
                .ToListAsync();
        }

        public async Task<ModelDto> GetByIdAsync(int id)
        {
            var item = await DbContext.Models.FirstOrDefaultAsync(c => c.Id == id);

            if(item == null)
            {
                return null;
            }

            return new ModelDto
            {
                Id = item.Id,
                Manufacturer = item.Manufacturer,
                Type = item.Type
            };
        }

        public Task<Model> Get(int id)
        {
            return Get<Model>(id);
        }

        public async Task<int> CountAsync(string searchString)
        {
            return await DbContext.Models
                .Where(s => string.IsNullOrEmpty(searchString) || s.Manufacturer.Contains(searchString) || s.Type.Contains(searchString))
                .CountAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await DbContext.Models.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistWithManufacturerAndName(string manufacturer, string name, int? id = null)
        {
            return await DbContext.Models.AnyAsync(x => x.Id != id && x.Manufacturer == manufacturer && x.Type == name);
        }

        //public async Task<IEnumerable<SelectedModel>> SelectAsync()
        //{
        //    var productsList = await DbContext.Models.Select(
        //       x => new { Value = x.Id, Text = x.Manufacturer + " " + x.Type }).ToListAsync();
        //    List<SelectedModel> models = new List<SelectedModel>();

        //    foreach (var item in productsList)
        //    {
        //        models.Add(new SelectedModel(item.Value, item.Text));
        //    }
        //    return models;
        //}
    }
}
