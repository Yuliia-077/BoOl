using BoOl.Application.Interfaces;
using BoOl.Persistence.DatabaseContext;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace BoOl.Persistence.Repositories
{
    public abstract class BaseRepository : IBaseRepository
    {
        private readonly DatabaseOptions _databaseOptions;
        protected readonly BoOlContext DbContext;

        protected BaseRepository(IOptions<DatabaseOptions> databaseOptions, BoOlContext dbContext)
        {
            DbContext = dbContext;
            _databaseOptions = databaseOptions?.Value ?? throw new ArgumentNullException(nameof(databaseOptions));
            if (databaseOptions.Value.SqlConnectionString is null)
            {
                throw new ArgumentNullException(nameof(databaseOptions.Value.SqlConnectionString));
            }
        }

        public Task SaveChanges()
        {
            return DbContext.SaveChangesAsync();
        }

        protected async Task<TEntity> Get<TEntity>(int id) where TEntity : class
        {
            return await DbContext.Set<TEntity>().FindAsync(id);
        }

        protected async Task Create<TEntity>(TEntity entity)
        {
            await DbContext.AddAsync(entity);
        }
    }
}
