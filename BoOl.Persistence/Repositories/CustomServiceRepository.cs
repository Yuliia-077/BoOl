using BoOl.Application.Interfaces;
using BoOl.Application.Models.CustomServices;
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
    }
}
