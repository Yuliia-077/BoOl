using BoOl.Models;
using BoOl.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Repository
{
    public class ServiceRepository : IRepository<Service>
    {
        private BoOlContext _context;

        
        public async Task AddAsync(Service t)
        {
            await _context.Services.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync(int? id)
        {
            if(id == null)
            {
                return await _context.Services.CountAsync();
            }
            else
            {
                var service = await GetByIdAsync(Convert.ToInt32(id));
                return service.CustomServices.Count();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var service = await GetByIdAsync(id);
            if(service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Service>> GetAllAsync(int? id)
        {
            return await _context.Services.Include(s => s.CustomServices).OrderBy(s => s.Name).ToListAsync();
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _context.Services.Include(s => s.CustomServices).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<SelectedModel>> SelectAsync()
        {
            var productsList = await _context.Services
                .Select(x => new { Value = x.Id, Text = x.Name }).ToListAsync();
            List<SelectedModel> models = new List<SelectedModel>();

            foreach (var item in productsList)
            {
                models.Add(new SelectedModel(item.Value, item.Text));
            }
            return models;
        }

        public ServiceRepository(BoOlContext context)
        {
            _context = context;
        }

        public async Task UpdateAsync(Service t)
        {
            if(t != null)
            {
                _context.Services.Update(t);
                await _context.SaveChangesAsync();
            }
        }
    }
}
