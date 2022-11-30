using BoOl.Application.Models;
using BoOl.Application.Models.Storages;
using BoOl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface IProductRepository : IBaseRepository
    {
        Task<bool> ExistItemsWithModel(int modelId);
    }
}
