using BoOl.Domain;
using BoOl.Persistence.DatabaseContext;
using BoOl.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Repository
{
    //отримання даних з бд по таблиці запчастини
    public class PartRepository : IRepository<Part>
    {
        private BoOlContext _context;
        private StorageRepository _storageRepository;

        public PartRepository(BoOlContext context)
        {
            _context = context;
            _storageRepository = new StorageRepository(context);
        }

        public async Task AddAsync(Part t)
        {
            await _context.Parts.AddAsync(t);
            Storage storage = await _storageRepository.GetByIdAsync(t.StorageId);
            storage.Quantity -= 1;
            await _storageRepository.UpdateAsync(storage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Part part = await GetByIdAsync(id);
            if (part != null)
            {
                if(part.IsInjured == false)
                {
                    part.Storage.Quantity += 1;
                    await _storageRepository.UpdateAsync(part.Storage);
                }
                _context.Parts.Remove(part);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Part>> GetAllAsync(int? id)
        {
            if (id == null)
            {
                return await _context.Parts.Include(p => p.Storage).OrderByDescending(c => c.Storage.Name).ToListAsync();
            }
            else
            {
                return await _context.Parts.Include(p => p.Storage)
                    .Where(p => p.CustomServiceId == id)
                    .OrderByDescending(c => c.Storage.Name).ToListAsync();
            }
        }

        public async Task<Part> GetByIdAsync(int id)
        {
            return await _context.Parts.Include(p => p.Storage).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Part t)
        {
            if (t != null)
            {
                _context.Parts.Update(t);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> CountAsync(int? id)
        {
            if (id != null)
            {
                return await _context.Parts.CountAsync(p => p.CustomServiceId == id);
            }
            else
            {
                return await _context.Parts.CountAsync();
            }
        }

        //змінити
        public async Task<IEnumerable<SelectedModel>> SelectAsync(int? id)
        {
            List<SelectedModel> models = new List<SelectedModel>();
            if (id != null)
            {
                var productsList = await _context.Products.Include(x => x.Model).Where(p => p.CustomerId == id)
               .Select(x => new { Value = x.Id, Text = x.SerialNumber }).ToListAsync();
                foreach (var item in productsList)
                {
                    models.Add(new SelectedModel(item.Value, item.Text));
                }
                return models;
            }
            else
            {
                var productsList = await _context.Products.Include(x => x.Model)
                .Select(x => new { Value = x.Id, Text = x.SerialNumber }).ToListAsync();
                foreach (var item in productsList)
                {
                    models.Add(new SelectedModel(item.Value, item.Text));
                }
                return models;
            }
        }
    }
}
