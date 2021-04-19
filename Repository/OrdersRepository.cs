using BoOl.Models;
using BoOl.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Repository
{
    public class OrdersRepository : IRepository<Order>
    {
        private BoOlContext _context;

        public OrdersRepository(BoOlContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order t)
        {
            if(t != null)
            {
                await _context.Orders.AddAsync(t);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> CountAsync(int? id)
        {
            if(id != null)
            {
                var order = await GetByIdAsync(Convert.ToInt32(id));
                if (order != null)
                {
                    return order.CustomServices.Count();
                }
            }
            return await _context.Orders.CountAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await GetByIdAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync(int? id)
        {
            return await _context.Orders.Include(o => o.CustomServices).Include(o => o.Worker)
                .Include(o => o.Product).ThenInclude(p => p.Customer)
                .OrderBy(o => o.DateOfAdmission).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.CustomServices).ThenInclude(o => o.Service)
                .Include(o => o.CustomServices).ThenInclude(o => o.Worker)
                .Include(o => o.Worker)
                .Include(o => o.Product.Customer)
                .Include(o => o.Product.Model).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<SelectedModel>> SelectAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Order t)
        {
            if (t != null)
            {
                _context.Orders.Update(t);
                await _context.SaveChangesAsync();
            }
        }
    }
}
