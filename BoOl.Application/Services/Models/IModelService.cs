using BoOl.Application.Models;
using BoOl.Application.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Models
{
    public interface IModelService
    {
        Task<IList<ModelListItemDto>> GetListItems(int currentPage, int pageSize, string searchString);
        Task<ModelDto> GetById(int id);
        Task<int> Count(string searchString);
        Task<int> Create(ModelDto dto);
        Task Update(ModelDto dto);
        Task Delete(int id);
        Task<IEnumerable<SelectListItem>> SelectListOfModelsAsync();
    }
}
