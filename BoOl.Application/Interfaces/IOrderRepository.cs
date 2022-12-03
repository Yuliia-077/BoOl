using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface IOrderRepository : IBaseRepository
    {
        Task<int> CountAllAsync();
    }
}
