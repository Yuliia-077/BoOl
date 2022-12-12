using BoOl.Application.Interfaces;
using BoOl.Application.Models.Parts;
using BoOl.Domain;
using BoOl.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Persistence.Repositories
{
    public class PartRepository : BaseRepository, IPartRepository
    {
        public PartRepository(IOptions<DatabaseOptions> databaseOptions, BoOlContext context) : base(databaseOptions, context) { }

        public async Task<bool> Exist(int id)
        {
            return await DbContext.Parts.AnyAsync(x => x.Id == id);
        }
        
        public async Task<bool> ExistWithStorageId(int storageId)
        {
            return await DbContext.CustomServices.AnyAsync(x => x.Parts.Any(y => y.StorageId == storageId));
        }

        public async Task<bool> ExistWithSerailNumber(string serialNumber, int? id)
        {
            return await DbContext.Parts.AnyAsync(x => x.Id != id && x.SerialNumber == serialNumber);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await Get(id);
            if (item != null)
            {
                DbContext.Parts.Remove(item);
            }
        }

        public async Task<int> Count(int customServiceId)
        {
            return await DbContext.Parts
                .Where(x => x.CustomServiceId == customServiceId)
                .CountAsync();

        }

        public async Task<IList<PartDto>> GetListAsync(int customServiceId, int currentPage, int pageSize)
        {
            return await DbContext.Parts
                .Where(x => x.CustomServiceId == customServiceId)
                .OrderByDescending(cs => cs.SerialNumber)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .Select(cs => new PartDto
                {
                    Id = cs.Id,
                    IsInjured = cs.IsInjured,
                    SerialNumber = cs.SerialNumber,
                    StorageId = cs.StorageId,
                    CustomServiceId = cs.CustomServiceId,
                    StorageName = cs.Storage.Name + " " + cs.Storage.Model.Manufacturer + " " + cs.Storage.Model.Type
                }).ToListAsync();
        }

        public Task<Part> Get(int id)
        {
            return Get<Part>(id);
        }

        public async Task AddAsync(Part item)
        {
            await Create<Part>(item);
        }

        public async Task<int> GetStorageId(int id)
        {
            return await DbContext.Parts
                .Where(x => x.Id == id)
                .Select(x => x.StorageId)
                .SingleOrDefaultAsync();
        }
    }
}
