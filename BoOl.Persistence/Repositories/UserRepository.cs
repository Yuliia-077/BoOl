using BoOl.Application.Interfaces;
using BoOl.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace BoOl.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IOptions<DatabaseOptions> databaseOptions, BoOlContext context) : base(databaseOptions, context) { }
        
        public async Task<int?> GetWorkerIdByUserEmail(string email)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user.WorkerId;
        }
    }
}
