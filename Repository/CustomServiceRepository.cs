using BoOl.Models;
using BoOl.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Repository
{
    //отримання даних з бд по таблиці послуги по замовленню
    public class CustomServiceRepository : IRepository<CustomService>
    {
        private BoOlContext _context;

        public CustomServiceRepository(BoOlContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CustomService t)
        {
            if(t!=null)
            {
                await _context.CustomServices.AddAsync(t);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> CountAsync(int? id)
        {
            if(id != null)
            {
                return await _context.CustomServices.Where(c => c.OrderId == id).CountAsync();
            }
            return await _context.CustomServices.CountAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customService = await GetByIdAsync(id);
            if(customService != null)
            {
                _context.CustomServices.Remove(customService);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CustomService>> GetAllAsync(int? id)
        {
            if(id != null)
            {
                return await _context.CustomServices.Where(c => c.OrderId == id).ToListAsync();
            }
            return await _context.CustomServices.ToListAsync();
        }

        public async Task<CustomService> GetByIdAsync(int id)
        {
            return await _context.CustomServices.Include(c => c.Order).Include(c => c.Parts).ThenInclude(p => p.Storage)
                .Include(c => c.Service).FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<IEnumerable<SelectedModel>> SelectAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(CustomService t)
        {
            if(t != null)
            {
                _context.CustomServices.Update(t);
                await _context.SaveChangesAsync();
            }
        }
    }
}
