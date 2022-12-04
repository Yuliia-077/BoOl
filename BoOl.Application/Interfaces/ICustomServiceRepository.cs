using BoOl.Application.Models.CustomServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface ICustomServiceRepository
    {
        Task<bool> ExistWithServiceId(int serviceId);
        Task<IList<CustomServiceListItemDto>> GetListAsync(int orderId, int currentPage, int pageSize);
    }
}
