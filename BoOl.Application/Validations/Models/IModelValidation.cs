using BoOl.Application.Models.Models;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Models
{
    public interface IModelValidation
    {
        Task<string> ValidationForCreateOrUpdate(ModelDto dto);
        Task<string> ValidationForDelete(int id);
    }
}
