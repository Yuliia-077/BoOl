using BoOl.Application.Interfaces;
using BoOl.Application.Models;
using BoOl.Application.Models.Customers;
using BoOl.Application.Models.Products;
using BoOl.Domain;
using BoOl.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Persistence.Repositories
{
    //отримання даних з бд по таблиці клієнт
    public class CustomerRepository: BaseRepository, ICustomerRepository
    {
        public CustomerRepository(IOptions<DatabaseOptions> databaseOptions, BoOlContext context) : base(databaseOptions, context) { }

        
        public async Task AddAsync(Customer item)
        {
            await Create<Customer>(item);
        }
      
        public async Task DeleteAsync(int id)
        {
            var customer = await Get(id);
            if(customer != null)
            {
                DbContext.Customers.Remove(customer);
            }
        }
        
        public async Task<IList<CustomerListItemDto>> GetAllAsync(int currentPage, int pageSize, string searchString)
        {
            return await DbContext.Customers
                .Where(s => string.IsNullOrEmpty(searchString) 
                    || (s.LastName.Contains(searchString) 
                        || s.FirstName.Contains(searchString) 
                        || s.Email.Contains(searchString)
                        || s.PhoneNumber.Contains(searchString)))
                .OrderBy(c => c.LastName)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new CustomerListItemDto
                {
                    Id = x.Id,
                    LastName = x.LastName,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email
                })
                .ToListAsync();
        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var item = await DbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);

            if(item == null)
            {
                return null;
            }

            return new CustomerDto
            {
                Id = item.Id,
                LastName = item.LastName,
                FirstName = item.FirstName,
                MiddleName = item.MiddleName,
                PhoneNumber = item.PhoneNumber,
                DateOfBirth = item.DateOfBirth,
                Address = item.Address,
                Email = item.Email,
                Discount = item.Discount
            };
        }

        public Task<Customer> Get(int id)
        {
            return Get<Customer>(id);
        }

        public async Task<int> CountAsync(string searchString)
        {
            return await DbContext.Customers
                .Where(s => string.IsNullOrEmpty(searchString)
                    || (s.LastName.Contains(searchString)
                        || s.FirstName.Contains(searchString)
                        || s.Email.Contains(searchString)
                        || s.PhoneNumber.Contains(searchString)))
                .CountAsync();
        }

        public async Task<IEnumerable<SelectListItem>> SelectAsync()
        {
            var productsList = await DbContext.Customers.Select(
               x => new { Value = x.Id, Text = x.LastName + " " + x.FirstName + " " + x.MiddleName}).ToListAsync();
            List<SelectListItem> models = new List<SelectListItem>();
            return models;
        }

        public async Task<CustomerDetailsDto> GetDetails(int id)
        {
            var item = await DbContext.Customers
                .Include(x => x.Products)
                .ThenInclude(x => x.Model)
                .Include(x => x.Products)
                .ThenInclude(x => x.Orders)
                .FirstOrDefaultAsync(x => x.Id == id);

            return new CustomerDetailsDto
            {
                Id = item.Id,
                LastName = item.LastName,
                FirstName = item.FirstName,
                MiddleName = item.MiddleName,
                PhoneNumber = item.PhoneNumber,
                DateOfBirth = item.DateOfBirth,
                Address = item.Address,
                Email = item.Email,
                Discount = item.Discount,
                Products = item.Products.Select(x => new ProductByCustomerListItemDto
                {
                    Id = x.Id,
                    SerialNumber = x.SerialNumber,
                    ModelManufacturer = x.Model.Manufacturer,
                    ModelType = x.Model.Type
                }).ToList(),

            };
        }
    }
}
