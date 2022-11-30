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
    //отримання даних з бд по таблиці техніка
    public class ProductRepository: IRepository<Product>
    {
        private BoOlContext _context;

        public ProductRepository(BoOlContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product t)
        {
            await _context.Products.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int? id)
        {
            if(id == null)
            {
                return await _context.Products.OrderByDescending(c => c.ModelId).ToListAsync();
            }
            else
            {
                return await _context.Products.Include(p=>p.Model)
                    .Include(p=>p.Orders)
                    .Where(p => p.CustomerId == id)
                    .OrderByDescending(c => c.ModelId).ToListAsync();
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Customer).Include(p => p.Model)
                .Include(p => p.Orders).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Product t)
        {
            if (t != null)
            {
                _context.Products.Update(t);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> CountAsync(int? id)
        {
            if(id!=null)
            {
                return await _context.Products.CountAsync(p => p.CustomerId == id);
            }
            else
            {
                return await _context.Products.CountAsync();
            }
        }

        public async Task<IEnumerable<SelectedModel>> SelectAsync(int? id)
        {
            List<SelectedModel> models = new List<SelectedModel>();
            if (id!=null)
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
