using BoOl.Models;
using BoOl.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Repository
{
    public class UserRepository
    {
        private BoOlContext _context;

        public UserRepository(BoOlContext context)
        {
            _context = context;
        }

        public Task AddAsync(User t)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == id);
        }

        public Task<IEnumerable<SelectedModel>> SelectAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User t)
        {
            throw new NotImplementedException();
        }
    }
}
