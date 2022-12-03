using System.Threading.Tasks;

namespace BoOl.Application.Services.Orders
{
    public interface IOrderService
    {

        Task<int> CountAll();
    }
}
