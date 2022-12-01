using BoOl.Application.Interfaces;
using BoOl.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Persistence.Repositories
{
    public class PartRepository : BaseRepository, IPartRepository
    {
        public PartRepository(IOptions<DatabaseOptions> databaseOptions, BoOlContext context) : base(databaseOptions, context) { }
        
        public async Task<bool> ExistWithStorageId(int storageId)
        {
            return await DbContext.CustomServices.AnyAsync(x => x.Parts.Any(y => y.StorageId == storageId));
        }
    }
}
