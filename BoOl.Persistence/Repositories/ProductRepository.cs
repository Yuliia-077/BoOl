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
    //отримання даних з бд по таблиці Product
    public class ProductRepository: BaseRepository, IProductRepository
    {
        public ProductRepository(IOptions<DatabaseOptions> databaseOptions, BoOlContext context) : base(databaseOptions, context) { }

        public async Task<bool> ExistItemsWithModel(int modelId)
        {
            return await DbContext.Products.AnyAsync(x => x.ModelId == modelId);
        }
    }
}
