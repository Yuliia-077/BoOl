using BoOl.Application.Interfaces;
using BoOl.Application.Models.Orders;
using BoOl.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Orders
{
    public class OrderValidation : IOrderValidation
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private List<string> _errors;

        public OrderValidation(IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _errors = new List<string>();
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task<string> ValidationForCreate(OrderDto dto)
        {
            if (dto.DateOfIssue != null && dto.DateOfIssue <= dto.DateOfAdmission)
            {
                _errors.Add($"Дата видачі має бути більше дати прийому.");
            }

            if (!await _productRepository.ExistForCustomerId(dto.CustomerId, dto.ProductId))
            {
                _errors.Add($"Для клієнта техніка не існує.");
            }
            else if(await _orderRepository.ExistActiveForProductId(dto.ProductId))
            {
                _errors.Add("Існує активне замовлення для даної техніки, спершу завершіть його.");
            }

            if (_errors.Count() > 0)
            {
                return string.Join(Environment.NewLine, _errors);
            }

            return null;
        }
        
        public async Task<string> ValidationForUpdate(OrderDto dto)
        {
            if (!await _orderRepository.Exist(dto.Id))
            {
                _errors.Add($"Замовлення з id = {dto.Id} не знайдено.");
            }
            else
            {
                if (dto.DateOfIssue != null && dto.DateOfIssue <= dto.DateOfAdmission)
                {
                    _errors.Add($"Дата видачі має бути більше дати прийому.");
                }

                var hasCustomServices = await _orderRepository.HasCustomServices(dto.Id);

                if (await _orderRepository.GetProductId(dto.Id) != dto.ProductId && hasCustomServices)
                {
                    _errors.Add($"Техніка не може бути змінена, тому що є вже виконані послуги по замовленню.");
                }

                if (dto.Status == Status.NeedToPay && dto.Payment)
                {
                    _errors.Add($"Статус не може бути {dto.Status}, тому що є вже оплаченим.");
                }
                else if (dto.Status == Status.Complete)
                {
                    if(!dto.Payment)
                        _errors.Add($"Статус не може бути {dto.Status}, тому що не є оплаченим.");

                    if (dto.DateOfIssue == null)
                        _errors.Add($"Статус не може бути {dto.Status}, тому що клієнт не забрав замовлення.");

                    if(await _orderRepository.NotAllCustomServicesCompleted(dto.Id))
                        _errors.Add($"Статус не може бути {dto.Status}, тому що не всі послуги виконані.");
                }
                else if (dto.Status == Status.Open && hasCustomServices)
                {
                    _errors.Add($"Статус не може бути {dto.Status}, тому що є вже виконані послуги по ньому.");
                }

            }

            if (_errors.Count() > 0)
            {
                return string.Join(Environment.NewLine, _errors);
            }

            return null;
        }
    }
}
