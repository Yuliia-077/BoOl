using BoOl.Application.Models;
using BoOl.Application.Models.Customers;
using BoOl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface ICustomerRepository : IBaseRepository
    {
        Task<bool> Exist(int id);
        Task<bool> ExistWithPhone(string phone, int? id = null);
        Task<bool> ExistWithEmail(string email, int? id = null);
        Task<IList<CustomerListItemDto>> GetAllAsync(int currentPage, int pageSize, string searchString);
        Task<CustomerDto> GetByIdAsync(int id);
        Task<CustomerDetailsDto> GetDetails(int id);
        Task<Customer> Get(int id);
        Task AddAsync(Customer t);
        Task DeleteAsync(int id);
        Task<int> CountAsync(string searchString);
        Task<IEnumerable<SelectListItem>> SelectAsync();
        Task<string> GetName(int id);
    }
}
