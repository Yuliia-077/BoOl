using BoOl.Application.Models;
using BoOl.Application.Models.Services;
using BoOl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface IServiceRepository : IBaseRepository
    {
        Task<IList<ServiceListItemDto>> GetListAsync(int currentPage, int pageSize, string searchString);
        Task<ServiceDto> GetByIdAsync(int id);
        Task<Service> Get(int id);
        Task AddAsync(Service t);
        Task DeleteAsync(int id);
        Task<int> CountAsync(string searchString);
        Task<bool> Exist(int id);
        Task<bool> ExistWithName(string name, int? id);
        Task<IList<ServiceListItemDto>> MostPopularServices(int pageSize);
        Task<IList<SelectListItem>> SelectAsync();
        Task<double> GetPriceById(int id);
    }
}
