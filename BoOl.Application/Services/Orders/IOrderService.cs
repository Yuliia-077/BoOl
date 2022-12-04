using BoOl.Application.Models.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Orders
{
    public interface IOrderService
    {
        Task<int> CountAll();
        Task<int> Count(string searchString);
        Task Delete(int id);
        Task<IList<OrderListItemDto>> GetList(int currentPage, int pageSize, string searchString);
        Task<OrderDetailsDto> GetDetails(int id, int currentPage, int pageSize);
        Task<OrderDto> GetById(int id);
        Task Update(OrderDto dto);
    }
}
