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

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
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
            var item = await _customerRepository.Get(dto.Id);

            if (item == null)
            {
                throw new ArgumentNullException("Користувача не знайдено.");
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
    }
}
