using BoOl.Application.Interfaces;
using BoOl.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
    }
}
