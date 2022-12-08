using BoOl.Application.Interfaces;
using BoOl.Application.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Customers
{
    public class CustomerValidation : ICustomerValidation
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private List<string> _errors;

        public CustomerValidation(ICustomerRepository customerRepository,
            IOrderRepository orderRepository)
        {
            _errors = new List<string>();
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        public async Task<string> ValidationForCreateOrUpdate(CustomerDto dto)
        {
            if (dto.Id.HasValue && !await _customerRepository.Exist(dto.Id.Value))
            {
                _errors.Add($"Клієнта з id = {dto.Id} не знайдено.");
            }

            if (await _customerRepository.ExistWithEmail(dto.Email, dto.Id))
            {
                _errors.Add($"Клієнт з електронною поштою = {dto.Email} вже існує в системі.");
            }

            if (await _customerRepository.ExistWithPhone(dto.PhoneNumber, dto.Id))
            {
                _errors.Add($"Клієнт з номером телефону = {dto.PhoneNumber} вже існує в системі.");
            }

            if (_errors.Count() > 0)
            {
                return string.Join(Environment.NewLine, _errors);
            }

            return null;
        }

        public async Task<string> ValidationForDelete(int id)
        {
            if(id == default)
            {
                _errors.Add("Id не забезпечене.");
            }
            else if(!await _customerRepository.Exist(id))
            {
                _errors.Add($"Клієнта з id = {id} не знайдено.");
            }
            else if(await _orderRepository.ExistForCustomerId(id))
            {
                _errors.Add("Для даного користувача існують замовлення, спершу видаліть їх.");
            }

            if (_errors.Count() > 0)
            {
                return string.Join(Environment.NewLine, _errors);
            }

            return null;
        }
    }
}
