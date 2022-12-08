using BoOl.Application.Interfaces;
using BoOl.Application.Models;
using BoOl.Application.Models.Products;
using BoOl.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        public ProductService(IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        public async  Task<IEnumerable<SelectListItem>> SelectListOfProductsByCustomerIdAsync(int customerId)
        {
            return await _productRepository.SelectAsync(customerId);
        }

        public async Task<ProductDetailsDto> GetDetails(int id, int orderCurrentPage, int pageSize)
        {
            var item = await _productRepository.GetDetails(id);

            if (item == null)
            {
                throw new ArgumentNullException("Техніку не знайдено.");
            }

            item.Orders = await _orderRepository.GetListAsync(orderCurrentPage, pageSize, null, item.CustomerId, id);
            item.CountOfOrders = await _orderRepository.Count(null, item.CustomerId, id);

            return item;
        }

        public async Task<ProductDto> GetById(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<int> Create(ProductDto dto)
        {
            var item = new Product
            {
                SerialNumber = dto.SerialNumber,
                ModelId = dto.ModelId,
                AdditionalInf = dto.AdditionalInf
            };

            await _productRepository.AddAsync(item);
            await _productRepository.SaveChanges();

            return item.Id;
        }

        public async Task Update(ProductDto dto)
        {
            var item = await _productRepository.Get(dto.Id.Value);

            if (item == null)
            {
                throw new ArgumentNullException("Техніку не знайдено.");
            }

            item.SerialNumber = dto.SerialNumber;
            item.ModelId = dto.ModelId;
            item.AdditionalInf = dto.AdditionalInf;

            await _productRepository.SaveChanges();
        }

        public async Task Delete(int id)
        {
            await _productRepository.DeleteAsync(id);
            await _productRepository.SaveChanges();
        }
    }
}
