using BoOl.Application.Interfaces;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Orders
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> CountAll()
        {
            return await _orderRepository.CountAllAsync();
        }
    }
}
