using BoOl.Application.Models.CustomServices;
using System.Threading.Tasks;

namespace BoOl.Application.Services.CustomServices
{
    public interface ICustomServicesService
    {
        Task<int> Create(CustomServiceDto dto, string userEmail);
        Task Update(CustomServiceDto dto);
        Task<CustomServiceDto> GetById(int id);
        Task<CustomServiceDetailsDto> GetDetails(int id);
        Task Delete(int id);
    }
}
