using BoOl.Application.Models;
using BoOl.Application.Models.Models;
using BoOl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface IModelRepository : IBaseRepository
    {
        Task<IList<ModelListItemDto>> GetListAsync(int currentPage, int pageSize, string searchString);
        Task<ModelDto> GetByIdAsync(int id);
        Task<Model> Get(int id);
        Task AddAsync(Model t);
        Task DeleteAsync(int id);
        Task<int> CountAsync(string searchString);
        Task<bool> ExistAsync(int id);
        Task<bool> ExistWithManufacturerAndName(string manufacturer, string name, int? id = null);
        Task<IEnumerable<SelectListItem>> SelectListOfModelsAsync();
    }
}
