using BoOl.Application.Models.Orders;
using BoOl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface IOrderRepository : IBaseRepository
    {
        Task<bool> ExistForCustomerId(int customerId);
        Task<bool> ExistForProductId(int productId);
        Task<int> CountAllAsync();
        Task<int> Count(string searchString, int? customerId = null, int? productId = null);
        Task AddAsync(Order item);
        Task<IList<OrderListItemDto>> GetListAsync(int currentPage, int pageSize, string searchString, int? customerId = null, int? productId = null);
        Task<OrderDetailsDto> GetDetails(int id);
        Task<Order> Get(int id);
        Task<OrderDto> GetById(int id);
        Task Delete(int id);
    }
}
