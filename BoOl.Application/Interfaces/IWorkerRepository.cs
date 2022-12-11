using BoOl.Application.Models.Workers;
using BoOl.Domain;
using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface IWorkerRepository : IBaseRepository
    {
        Task<bool> Exist(int id);
        Task<bool> ExistWithPhone(string phone, int? id = null);
        Task<bool> ExistForPositionId(int positionId);
        //Task<bool> ExistWithEmail(string email, int? id = null);
        Task<WorkerDto> GetByIdAsync(int id);
        Task<WorkerDetailsDto> GetDetails(int id);
        Task<Worker> Get(int id);
        Task AddAsync(Worker item);
        Task DeleteAsync(int id);
    }
}
