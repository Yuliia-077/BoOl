using BoOl.Application.Models.Workers;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Workers
{
    public interface IWorkerService
    {
        Task<WorkerDto> GetById(int id);
        Task<int> Create(WorkerDto dto);
        Task Update(WorkerDto dto);
        Task<WorkerDetailsDto> GetDetails(int id, int orderCurrentPage, int storageCurrentPage, int customServicesCurrentPage, int pageSize);
        Task Delete(int id);
    }
}
