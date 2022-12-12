using BoOl.Application.Models.CustomServices;
using BoOl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface ICustomServiceRepository : IBaseRepository
    {
        Task<bool> Exist(int id);
        Task<bool> ExistWithServiceId(int serviceId);
        Task<bool> ExistByWorkerId(int workerId);
        Task<bool> ExistServiceForModule(int id, int modelId);
        Task<bool> IsDone(int id);
        Task<int> CountByWorkerId(int workerId);
        Task<IList<CustomServiceListItemDto>> GetListAsync(int currentPage, int pageSize, int? orderId = null, int? workerId = null);
        Task DeleteAsync(int id);
        Task AddAsync(CustomService item);
        Task<CustomServiceDto> GetByIdAsync(int id);
        Task<CustomService> Get(int id);
        Task<CustomServiceDetailsDto> GetDetails(int id);
    }
}
