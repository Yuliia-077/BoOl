using BoOl.Application.Interfaces;
using BoOl.Application.Models.Orders;
using BoOl.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Orders
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomServiceRepository _customServiceRepository;
        private readonly IUserRepository _userRepository;

        public OrderService(IOrderRepository orderRepository,
            ICustomServiceRepository customServiceRepository,
            IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _customServiceRepository = customServiceRepository;
            _userRepository = userRepository;
        }

        public async Task<int> CountAll()
        {
            return await _orderRepository.CountAllAsync();
        }

        public async Task<int> Count(string searchString)
        {
            return await _orderRepository.Count(searchString);
        }

        public async Task<IList<OrderListItemDto>> GetList(int currentPage, int pageSize, string searchString)
        {
            return await _orderRepository.GetListAsync(currentPage, pageSize, searchString);
        }

        public async Task<OrderDetailsDto> GetDetails(int id, int currentPage, int pageSize)
        {
            var item = await _orderRepository.GetDetails(id);
            item.CustomServices = await _customServiceRepository.GetListAsync(id, currentPage, pageSize);
            return item;
        }

        public async Task Delete(int id)
        {
            await _orderRepository.Delete(id);
            await _orderRepository.SaveChanges();
        }

        public async Task<OrderDto> GetById(int id)
        {
            return await _orderRepository.GetById(id);
        }

        public async Task Update(OrderDto dto)
        {
            var item = await _orderRepository.Get(dto.Id);

            if (item == null)
            {
                throw new ArgumentNullException("Замовлення не знайдено.");
            }

            item.Payment = dto.Payment;
            item.Status = dto.Status;
            item.Discount = dto.Discount;
            item.ProductId = dto.ProductId;
            item.DateOfAdmission = dto.DateOfAdmission;
            item.DateOfIssue = dto.DateOfIssue;

            await _orderRepository.SaveChanges();
        }

        public async Task<int> Create(OrderDto dto, string userEmail)
        {
            var workerId = await _userRepository.GetWorkerIdByUserEmail(userEmail);
            if (workerId == null)
            {
                throw new ArgumentNullException("Користувача не знайдено.");
            }

            var item = new Order
            {
                Payment = dto.Payment,
                Status = dto.Status,
                Discount = dto.Discount,
                ProductId = dto.ProductId,
                DateOfAdmission = dto.DateOfAdmission,
                DateOfIssue = dto.DateOfIssue,
                WorkerId = workerId.Value
            };

            await _orderRepository.AddAsync(item);
            await _orderRepository.SaveChanges();
            return item.Id;
        }
    }
}
