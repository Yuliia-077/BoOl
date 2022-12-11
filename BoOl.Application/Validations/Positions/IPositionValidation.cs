using BoOl.Application.Models.Positions;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Positions
{
    public interface IPositionValidation
    {
        Task<string> ValidationForCreateOrUpdate(PositionDto dto);
        Task<string> ValidationForDelete(int id);
    }
}
