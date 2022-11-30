using BoOl.Application.Models.Services;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Services
{
    public interface IServiceValidation
    {
        Task<string> ValidationForCreateOrUpdate(ServiceDto dto);
        Task<string> ValidationForDelete(int id);
    }
}
