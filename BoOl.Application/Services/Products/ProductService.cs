using BoOl.Application.Interfaces;
using BoOl.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async  Task<IEnumerable<SelectListItem>> SelectListOfProductsByCustomerIdAsync(int customerId)
        {
            return await _productRepository.SelectAsync(customerId);
        }
    }
}
