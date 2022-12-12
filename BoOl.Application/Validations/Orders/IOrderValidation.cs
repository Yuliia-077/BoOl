using BoOl.Application.Models.Orders;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Orders
{
    public interface IOrderValidation
    {
        Task<string> ValidationForCreate(OrderDto dto);
        Task<string> ValidationForUpdate(OrderDto dto);
    }
}
