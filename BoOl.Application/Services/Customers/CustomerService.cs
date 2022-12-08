using BoOl.Application.Interfaces;
using BoOl.Application.Models.Customers;
using BoOl.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public CustomerService(ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<IList<CustomerListItemDto>> GetListItems(int currentPage, int pageSize, string searchString)
        {
            return await _customerRepository.GetAllAsync(currentPage, pageSize, searchString);
        }

        public async Task<int> Count(string searchString)
        {
            return await _customerRepository.CountAsync(searchString);
        }

        public async Task<int> Create(CustomerDto dto)
        {
            var item = new Customer
            {
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                PhoneNumber = dto.PhoneNumber,
                DateOfBirth = dto.DateOfBirth,
                Address = dto.Address,
                Email = dto.Email,
                Discount = dto.Discount
            };
            await _customerRepository.AddAsync(item);
            await _customerRepository.SaveChanges();

            return item.Id;
        }

        public async Task<CustomerDto> GetById(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task Update(CustomerDto dto)
        {
            var item = await _customerRepository.Get(dto.Id.Value);

            if (item == null)
            {
                throw new ArgumentNullException("Клієнта не знайдено.");
            }

            item.Address = dto.Address;
            item.DateOfBirth = dto.DateOfBirth;
            item.Discount = dto.Discount;
            item.Email = dto.Email;
            item.FirstName = dto.FirstName;
            item.LastName = dto.LastName;
            item.MiddleName = dto.MiddleName;
            item.PhoneNumber = dto.PhoneNumber;

            await _customerRepository.SaveChanges();
        }

        public async Task<CustomerDetailsDto> GetDetails(int id, int orderCurrentPage, int partCurrentPage, int pageSize)
        {
            var item = await _customerRepository.GetDetails(id);

            if (item == null)
            {
                throw new ArgumentNullException("Клієнта не знайдено.");
            }

            item.Products = await _productRepository.GetListByCustomerId(partCurrentPage, pageSize, id);
            item.CountOfProducts = await _productRepository.CountByCustomerId(id);

            item.Orders = await _orderRepository.GetListAsync(orderCurrentPage, pageSize, null, id);
            item.CountOfOrders = await _orderRepository.Count(null, id);

            return item;
        }

        public async Task Delete(int id)
        {
            await _customerRepository.DeleteAsync(id);
            await _customerRepository.SaveChanges();
        }

        public async Task<string> GetName(int id)
        {
            return await _customerRepository.GetName(id);
        }
    }
}
