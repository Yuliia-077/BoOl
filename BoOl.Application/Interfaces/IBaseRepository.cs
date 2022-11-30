using System.Threading.Tasks;

namespace BoOl.Application.Interfaces
{
    public interface IBaseRepository
    {
        Task SaveChanges();
    }
}
