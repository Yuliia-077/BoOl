using BoOl.Application.Models.CustomServices;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.CustomServices
{
    public interface ICustomServiceValidation
    {
        Task<string> ValidationForCreateOrUpdate(CustomServiceDto dto);
    }
}
