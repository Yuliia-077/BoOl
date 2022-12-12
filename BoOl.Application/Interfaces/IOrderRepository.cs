using BoOl.Application.Models.Orders;
using BoOl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface IOrderRepository : IBaseRepository
    {
        Task<bool> Exist(int id);
        Task<bool> ExistForCustomerId(int customerId);
        Task<bool> ExistForWorkerId(int workerId);
        Task<bool> ExistForProductId(int productId);
        Task<bool> ExistActiveForProductId(int productId);
        Task<bool> NotAllCustomServicesCompleted(int id);
        Task<bool> HasCustomServices(int id);
        Task<int> CountAllAsync();
        Task<int> Count(string searchString, int? customerId = null, int? productId = null, int? workerId = null);
        Task AddAsync(Order item);
        Task<int> GetProductId(int id);
        Task<IList<OrderListItemDto>> GetListAsync(int currentPage, int pageSize, string searchString, int? customerId = null, int? productId = null, int? workerId = null);
        Task<OrderDetailsDto> GetDetails(int id);
        Task<Order> Get(int id);
        Task<OrderDto> GetById(int id);
        Task Delete(int id);
    }
}
