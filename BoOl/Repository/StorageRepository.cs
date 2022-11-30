using BoOl.Application.Models;
using BoOl.Domain;
using BoOl.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Repository
{
    //отримання даних з бд по таблиці склад
    public class StorageRepository : IRepository<Storage>
    {
        private BoOlContext _context;

        public StorageRepository(BoOlContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Storage t)
        {
            if (t != null)
            {
                await _context.Storages.AddAsync(t);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> CountAsync(int? id)
        {
            return await _context.Storages.CountAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var storage = await GetByIdAsync(id);
            _context.Storages.Remove(storage);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Storage>> GetAllAsync(int? id)
        {
            return await _context.Storages.Include(s => s.Model).OrderBy(s => s.Name).ToListAsync();
        }

        public async Task<Storage> GetByIdAsync(int id)
        {
            return await _context.Storages.Include(s => s.Worker).Include(s => s.Model).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<SelectedModel>> SelectAsync(int? id)
        {
            var deliveryList = await _context.Storages.Include(s => s.Model)
                .Where(s => s.Quantity >= 1).Select(
               x => new { Value = x.Id, Text = x.Name + " " + x.Model.Manufacturer + " " + x.Model.Type})
                .ToListAsync();
            List<SelectedModel> models = new List<SelectedModel>();

            foreach (var item in deliveryList)
            {
                models.Add(new SelectedModel(item.Value, item.Text));
            }
            return models;
        }

        public async Task UpdateAsync(Storage t)
        {
            if(t != null)
            {
                _context.Storages.Update(t);
                await _context.SaveChangesAsync();
            }
        }
    }
}
