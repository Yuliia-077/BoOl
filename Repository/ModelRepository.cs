using BoOl.Models;
using BoOl.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Repository
{
    //отримання даних з бд по таблиці моделі
    public class ModelRepository : IRepository<Model>
    {
        private BoOlContext _context;

        public ModelRepository(BoOlContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Model t)
        {
            await _context.Models.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync(int? id)
        {
            return await _context.Models.CountAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var model = await GetByIdAsync(id);
            if (model != null)
            {
                _context.Models.Remove(model);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Model>> GetAllAsync(int? id)
        {
            return await _context.Models.ToListAsync();
        }

        public async Task<Model> GetByIdAsync(int id)
        {
            return await _context.Models.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Model t)
        {
            if (t != null)
            {
                _context.Models.Update(t);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<SelectedModel>> SelectAsync(int? id)
        {
            var productsList = await _context.Models.Select(
               x => new { Value = x.Id, Text = x.Manufacturer + " " + x.Type }).ToListAsync();
            List<SelectedModel> models = new List<SelectedModel>();

            foreach (var item in productsList)
            {
                models.Add(new SelectedModel(item.Value, item.Text));
            }
            return models;
        }
    }
}
