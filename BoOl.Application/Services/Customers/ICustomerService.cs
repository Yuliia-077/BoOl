using BoOl.Application.Models.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Customers
{
    public interface ICustomerService
    {
        Task<IList<CustomerListItemDto>> GetListItems(int currentPage, int pageSize, string searchString);
        Task<CustomerDto> GetById(int id);
        Task<int> Count(string searchString);
        Task<int> Create(CustomerDto dto);
        Task Update(CustomerDto dto);
    }
}
