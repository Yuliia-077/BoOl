using BoOl.Application.Interfaces;
using BoOl.Application.Models.CustomServices;
using BoOl.Domain;
using BoOl.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Persistence.Repositories
{
    public class CustomServiceRepository : BaseRepository, ICustomServiceRepository
    {
        public CustomServiceRepository(IOptions<DatabaseOptions> databaseOptions, BoOlContext context) : base(databaseOptions, context) { }
        
        public async Task<bool> ExistWithServiceId(int serviceId)
        {
            return await DbContext.CustomServices.AnyAsync(x => x.ServiceId == serviceId);
        }

        public async Task<IList<CustomServiceListItemDto>> GetListAsync(int orderId, int currentPage, int pageSize)
        {
            return await DbContext.CustomServices
                .Where(x => x.OrderId == orderId)
                .OrderByDescending(cs => cs.ExecutionDate)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .Select(cs => new CustomServiceListItemDto
                {
                    Id = cs.Id,
                    IsDone = cs.IsDone,
                    ExecutionDate = cs.ExecutionDate,
                    WorkerId = cs.WorkerId,
                    WorkerName = cs.Worker.LastName + " " + cs.Worker.FirstName,
                    ServiceId = cs.ServiceId,
                    ServiceName = cs.Service.Name
                }).ToListAsync();
        }
        
        public async Task<CustomServiceDetailsDto> GetDetails(int id)
        {
            return await DbContext.CustomServices
                .Where(x => x.Id == id)
                .Select(cs => new CustomServiceDetailsDto
                {
                    Id = cs.Id,
                    IsDone = cs.IsDone,
                    ExecutionDate = cs.ExecutionDate,
                    WorkerId = cs.WorkerId,
                    WorkerName = cs.Worker.LastName + " " + cs.Worker.FirstName,
                    ServiceId = cs.ServiceId,
                    ServiceName = cs.Service.Name,
                    OrderId = cs.OrderId,
                    Price = cs.Price
                }).SingleOrDefaultAsync();
        }

        public Task<CustomService> Get(int id)
        {
            return Get<CustomService>(id);
        }

        public async Task<CustomServiceDto> GetByIdAsync(int id)
        {
            var item = await DbContext.CustomServices
                .SingleOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                return null;
            }

            return new CustomServiceDto
            {
                Id = item.Id,
                IsDone = item.IsDone,
                ExecutionDate = item.ExecutionDate,
                ServiceId = item.ServiceId,
                OrderId = item.OrderId
            };
        }

        public async Task AddAsync(CustomService item)
        {
            await Create<CustomService>(item);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await Get(id);
            if (item != null)
            {
                var parts = DbContext.Parts.Where(x => x.CustomServiceId == id);
                DbContext.Parts.RemoveRange(parts);
                DbContext.CustomServices.Remove(item);
            }
        }
    }
}
