using BoOl.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface IProductRepository : IBaseRepository
    {
        Task<bool> ExistItemsWithModel(int modelId);
        Task<IEnumerable<SelectListItem>> SelectAsync(int customerId);
    }
}
