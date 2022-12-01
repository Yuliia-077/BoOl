using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface IPartRepository
    {
        Task<bool> ExistWithStorageId(int serviceId);
    }
}
