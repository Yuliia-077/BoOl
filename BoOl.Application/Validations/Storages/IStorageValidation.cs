using BoOl.Application.Models.Storages;
using System.Threading.Tasks;

namespace BoOl.Application.Validations.Services
{
    public interface IStorageValidation
    {
        Task<string> ValidationForCreateOrUpdate(StorageDto dto);
        Task<string> ValidationForDelete(int id);
    }
}
