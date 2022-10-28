using BoOl.Domain;
using BoOl.Persistence.DatabaseContext;
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

        // пошук користувача по електронній пошті
        public async Task<User> GetByIdAsync(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == id);
        }
    }
}
