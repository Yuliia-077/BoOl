using BoOl.Application.Interfaces;
using BoOl.Application.Models;
using BoOl.Application.Models.Positions;
using BoOl.Application.Models.Workers;
using BoOl.Domain;
using BoOl.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Persistence.Repositories
{
    public class PositionRepository : BaseRepository, IPositionRepository
    {
        public PositionRepository(IOptions<DatabaseOptions> databaseOptions, BoOlContext context) : base(databaseOptions, context) { }

        public async Task<bool> Exist(int id)
        {
            return await DbContext.Positions.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistByName(string name, int? id = null)
        {
            return await DbContext.Positions.AnyAsync(x => x.Name == name && x.Id != id);
        }

        public async Task<IList<PositionListItemDto>> GetListAsync(string filter, bool isActive)
        {
            return await DbContext.Positions
                .Where(x => (string.IsNullOrEmpty(filter)
                    || x.Name.Contains(filter)
                    || x.Workers.Any(x => x.LastName.Contains(filter)
                                        || x.FirstName.Contains(filter)
                                        || x.PhoneNumber.Contains(filter))))
                .OrderBy(x => x.Name)
                .Select(cs => new PositionListItemDto
                {
                    Id = cs.Id,
                    Name = cs.Name,
                    Workers = cs.Workers
                            .Where(x => x.IsActive == isActive
                                && (string.IsNullOrEmpty(filter)
                                    || (!cs.Name.Contains(filter)
                                        && (x.LastName.Contains(filter)
                                            || x.FirstName.Contains(filter)
                                            || x.PhoneNumber.Contains(filter)))))
                            .OrderBy(x => x.LastName)
                            .ThenBy(x => x.FirstName)
                            .Select(x => new WorkerListItemDto
                            {
                                Id = x.Id,
                                Name = x.LastName + " " + x.FirstName,
                                NumberPhone = x.PhoneNumber
                            }).ToList()
                }).ToListAsync();
        }

        public Task<Position> Get(int id)
        {
            return Get<Position>(id);
        }

        public async Task<PositionDto> GetById(int id)
        {
            var item = await DbContext.Positions
                .Where(x => x.Id == id)
                .Select(x => new PositionDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Salary = x.Salary,
                    PercentageOfWork = x.PercentageOfWork
                }
                )
                .SingleOrDefaultAsync();

            if (item == null)
            {
                return null;
            }

            return item;
        }

        public async Task<IList<SelectListItem>> SelectAsync()
        {
            return await DbContext.Positions
                .Select(x => new SelectListItem {
                   Value = x.Id, 
                   Text = x.Name })
                .ToListAsync();
        }

        public async Task AddAsync(Position item)
        {
            await Create<Position>(item);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await Get(id);
            if (item != null)
            {
                DbContext.Positions.Remove(item);
            }
        }
    }
}
