using BoOl.Application.Interfaces;
using BoOl.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace BoOl.Persistence.Repositories
{
    //отримання даних з бд по таблиці замовлення
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(IOptions<DatabaseOptions> databaseOptions, BoOlContext context) : base(databaseOptions, context) { }

        public async Task<int> CountAllAsync()
        {
            return await DbContext.Orders
                .CountAsync();
        }
    }
}
