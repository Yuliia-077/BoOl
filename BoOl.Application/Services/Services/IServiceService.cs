using BoOl.Application.Models.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Services
{
    public interface IServiceService
    {
        Task<IList<ServiceListItemDto>> GetListItems(int currentPage, int pageSize, string searchString);
        Task<ServiceDto> GetById(int id);
        Task<int> Count(string searchString);
        Task<int> Create(ServiceDto dto);
        Task Update(ServiceDto dto);
        Task Delete(int id);
    }
}
