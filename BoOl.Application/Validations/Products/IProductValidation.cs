using BoOl.Application.Models.Products;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Products
{
    public interface IProductValidation
    {
        Task<string> ValidationForCreateOrUpdate(ProductDto dto);
        Task<string> ValidationForDelete(int id);
    }
}
