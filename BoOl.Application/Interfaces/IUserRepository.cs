using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<int?> GetWorkerIdByUserEmail(string email);
    }
}
