using BoOl.Application.Models.Customers;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Customers
{
    public interface ICustomerValidation
    {
        Task<string> ValidationForCreateOrUpdate(CustomerDto dto);
        Task<string> ValidationForDelete(int id);
    }
}
