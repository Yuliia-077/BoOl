using BoOl.Models;
using BoOl.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Repository
{
    public class CustomerRepository: IRepository<Customer>
    {
        private readonly BoOlContext _context;

        public CustomerRepository(BoOlContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer t)
        {
            await _context.Customers.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Customer customer = await GetByIdAsync(id);
            if(customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(int? id)
        {
            return await _context.Customers.OrderBy(c => c.LastName).ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Customer t)
        {
            if(t!=null)
            {
                _context.Customers.Update(t);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> CountAsync(int? id)
        {
            return await _context.Customers.CountAsync();
        }

        public async Task<IEnumerable<SelectedModel>> SelectAsync()
        {
            var productsList = await _context.Customers.Select(
               x => new { Value = x.Id, Text = x.LastName + " " + x.FirstName + " " + x.MiddleName}).ToListAsync();
            List<SelectedModel> models = new List<SelectedModel>();

            foreach (var item in productsList)
            {
                models.Add(new SelectedModel(item.Value, item.Text));
            }
            return models;
        }
    }
}
