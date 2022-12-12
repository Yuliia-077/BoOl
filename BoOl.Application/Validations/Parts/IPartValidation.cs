using BoOl.Application.Models.Parts;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Parts
{
    public interface IPartValidation
    {
        Task<string> ValidationForCreateOrUpdate(PartDto dto);
    }
}
