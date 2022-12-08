using BoOl.Application.Models;
using BoOl.Application.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<SelectListItem>> SelectListOfProductsByCustomerIdAsync(int customerId);
        Task<ProductDetailsDto> GetDetails(int id, int orderCurrentPage, int pageSize);
        Task<ProductDto> GetById(int id);
        Task<int> Create(ProductDto dto);
        Task Update(ProductDto dto);
        Task Delete(int id);
    }
}
