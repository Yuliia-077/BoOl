using BoOl.Application.Interfaces;
using BoOl.Application.Models.Services;
using BoOl.Domain;
using BoOl.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Persistence.Repositories
{
    //отримання даних з бд по таблиці Service
    public class ServiceRepository: BaseRepository, IServiceRepository
    {
        public ServiceRepository(IOptions<DatabaseOptions> databaseOptions, BoOlContext context) : base(databaseOptions, context) { }

        
        public async Task AddAsync(Service item)
        {
            await Create<Service>(item);
        }
      
        public async Task DeleteAsync(int id)
        {
            var Service = await Get(id);
            if(Service != null)
            {
                DbContext.Services.Remove(Service);
            }
        }
        
        public async Task<IList<ServiceListItemDto>> GetListAsync(int currentPage, int pageSize, string searchString)
        {
            return await DbContext.Services
                .Where(s => string.IsNullOrEmpty(searchString) || s.Name.Contains(searchString))
                .OrderBy(c => c.Name)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new ServiceListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                })
                .ToListAsync();
        }

        public async Task<ServiceDto> GetByIdAsync(int id)
        {
            var item = await DbContext.Services.FirstOrDefaultAsync(c => c.Id == id);

            if(item == null)
            {
                return null;
            }

            return new ServiceDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price
            };
        }

        public Task<Service> Get(int id)
        {
            return Get<Service>(id);
        }

        public async Task<int> CountAsync(string searchString)
        {
            return await DbContext.Services
                .Where(s => string.IsNullOrEmpty(searchString) || s.Name.Contains(searchString))
                .CountAsync();
        }

        public async Task<bool> Exist(int id)
        {
            return await DbContext.Services.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistWithName(string name, int? id)
        {
            return await DbContext.Services.AnyAsync(x => x.Name == name && x.Id != id);
        }

        public async Task<IList<ServiceListItemDto>> MostPopularServices(int pageSize)
        {
            return await DbContext.Services
                .Include(x => x.CustomServices)
                .OrderByDescending(x => x.CustomServices.Count())
                .Take(pageSize)
                .Select(x => new ServiceListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                }).ToListAsync();
        }


        //public async Task<IEnumerable<SelectedModel>> SelectAsync()
        //{
        //    var productsList = await DbContext.Services
        //        .Select(x => new { Value = x.Id, Text = x.Name }).ToListAsync();
        //    List<SelectedModel> models = new List<SelectedModel>();

        //    foreach (var item in productsList)
        //    {
        //        models.Add(new SelectedModel(item.Value, item.Text));
        //    }
        //    return models;
        //}
    }
}
