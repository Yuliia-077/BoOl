using BoOl.Application.Models;
using BoOl.Application.Models.Products;
using BoOl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface IProductRepository : IBaseRepository
    {
        Task<bool> Exist(int id);
        Task<bool> ExistWithSerialNumber(string serial, int? id = null);
        Task<bool> ExistItemsWithModel(int modelId);
        Task<IEnumerable<SelectListItem>> SelectAsync(int customerId);
        Task<int> CountByCustomerId(int customerId);
        Task<IList<ProductListItemDto>> GetListByCustomerId(int currentPage, int pageSize, int customerId);
        Task<ProductDetailsDto> GetDetails(int id);
        Task<ProductDto> GetById(int id);
        Task<Product> Get(int id);
        Task AddAsync(Product item);
        Task DeleteAsync(int id);
    }
}
