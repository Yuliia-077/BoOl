using BoOl.Application.Models.Workers;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Workers
{
    public interface IWorkerValidation
    {
        Task<string> ValidationForCreateOrUpdate(WorkerDto dto);
        Task<string> ValidationForDelete(int id);
    }
}
