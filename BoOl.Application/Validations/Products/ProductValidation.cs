using BoOl.Application.Interfaces;
using BoOl.Application.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Products
{
    public class ProductValidation : IProductValidation
    {
        private readonly IModelRepository _modelRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private List<string> _errors;

        public ProductValidation(IModelRepository modelRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _errors = new List<string>();
            _modelRepository = modelRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task<string> ValidationForCreateOrUpdate(ProductDto dto)
        {
            if(dto.Id.HasValue && !await _productRepository.Exist(dto.Id.Value))
            {
                _errors.Add($"Постачання з id = {dto.Id} не знайдено.");
            }
            else
            {
                var item = await _productRepository.GetById(dto.Id.Value);
                
                if(item.ModelId != dto.ModelId && await _orderRepository.ExistForProductId(dto.Id.Value))
                {
                    _errors.Add($"Неможливо змінити модель, тому що створено замовлення.");
                }
            }
            
            if(! await _modelRepository.ExistAsync(dto.ModelId))
            {
                _errors.Add($"Модель з id = {dto.ModelId} не знайдено.");
            }

            if (await _productRepository.ExistWithSerialNumber(dto.SerialNumber, dto.Id))
            {
                _errors.Add("Серійний номер вже існує в системі.");
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
            else if(!await _productRepository.Exist(id))
            {
                _errors.Add($"Течніку з id = {id} не знайдено.");
            }
            else if(await _orderRepository.ExistForProductId(id))
            {
                _errors.Add("Для даної техніки є замовлення, видаліть спершу його.");
            }

            if (_errors.Count() > 0)
            {
                return string.Join(Environment.NewLine, _errors);
            }

            return null;
        }
    }
}
