using BoOl.Models;
using BoOl.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Repository
{
    //отримання даних з бд по таблиці співробітник
    public class WorkerRepository : IRepository<Worker>
    {
        private BoOlContext _context;

        public WorkerRepository(BoOlContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Worker t)
        {
            await _context.Workers.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync(int? id)
        {
            if(id != null)
            {
                var worker = await GetByIdAsync(Convert.ToInt32(id));
                if (worker.Orders.Any() != false)
                {
                    return worker.Orders.Count();
                }
                if (worker.CustomServices.Any() == true)
                {
                    return worker.CustomServices.Count();
                }
            }
            return await _context.Workers.CountAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var worker = await GetByIdAsync(id);
            if(worker!= null)
            {
                _context.Workers.Remove(worker);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Worker>> GetAllAsync(int? id)
        {
            return await _context.Workers.ToListAsync();
        }

        public async Task<Worker> GetByIdAsync(int id)
        {
            return await _context.Workers.Include(w => w.Position)
                .Include(w => w.Orders)
                .Include(w => w.CustomServices)
                .Include(w => w.Storages)
                .Include(w => w.User)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<SelectedModel>> SelectAsync(int? id)
        {
            var productsList = await _context.Workers.Include(w => w.Position).Select(
               x => new { Value = x.Id, Text = x.LastName + " " + x.FirstName + " " + x.MiddleName + " " + x.Position.Name })
                .ToListAsync();
            List<SelectedModel> models = new List<SelectedModel>();

            foreach (var item in productsList)
            {
                models.Add(new SelectedModel(item.Value, item.Text));
            }
            return models;
        }

        public async Task UpdateAsync(Worker t)
        {
            if(t != null)
            {
                _context.Workers.Update(t);
                await _context.SaveChangesAsync();
            }
        }
    }
}
