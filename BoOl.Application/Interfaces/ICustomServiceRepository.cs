using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface ICustomServiceRepository
    {
        Task<bool> ExistWithServiceId(int serviceId);
    }
}
