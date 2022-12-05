using BoOl.Application.Models.CustomServices;
using BoOl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface ICustomServiceRepository : IBaseRepository
    {
        Task<bool> ExistWithServiceId(int serviceId);
        Task<IList<CustomServiceListItemDto>> GetListAsync(int orderId, int currentPage, int pageSize);
        Task DeleteAsync(int id);
        Task AddAsync(CustomService item);
        Task<CustomServiceDto> GetByIdAsync(int id);
        Task<CustomService> Get(int id);
        Task<CustomServiceDetailsDto> GetDetails(int id);
    }
}
