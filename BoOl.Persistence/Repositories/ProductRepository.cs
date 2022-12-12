using BoOl.Application.Interfaces;
using BoOl.Application.Models;
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
    //отримання даних з бд по таблиці Product
    public class ProductRepository: BaseRepository, IProductRepository
    {
        public ProductRepository(IOptions<DatabaseOptions> databaseOptions, BoOlContext context) : base(databaseOptions, context) { }

        public async Task<bool> Exist(int id)
        {
            return await DbContext.Products.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistWithSerialNumber(string serial, int? id = null)
        {
            return await DbContext.Products.AnyAsync(x => x.Id != id && x.SerialNumber == serial);
        }

        public async Task<bool> ExistItemsWithModel(int modelId)
        {
            return await DbContext.Products.AnyAsync(x => x.ModelId == modelId);
        }

        public async Task<bool> ExistForCustomerId(int customerId, int productId)
        {
            return await DbContext.Products
                .AnyAsync(x => x.CustomerId == customerId && x.Id == productId);
        }

        public async Task<int> CountByCustomerId(int customerId)
        {
            return await DbContext.Products
                .Where(x => x.CustomerId == customerId)
                .CountAsync();
        }

        public async Task<IList<ProductListItemDto>> GetListByCustomerId(int currentPage, int pageSize, int customerId)
        {
            return await DbContext.Products
                .Where(x => x.CustomerId == customerId)
                .OrderBy(x => x.Model.Manufacturer)
                .ThenBy(x => x.Model.Type)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new ProductListItemDto
                {
                    Id = x.Id,
                    Model = x.Model.Manufacturer + " " + x.Model.Type,
                    SerialNumber = x.SerialNumber
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> SelectAsync(int customerId)
        {
            return await DbContext.Products
                .Where(x => x.CustomerId == customerId)
                .OrderBy(x => x.Model.Manufacturer)
                .ThenBy(x => x.Model.Type)
                .Select(x => new SelectListItem
                {
                    Value = x.Id,
                    Text = x.Model.Manufacturer + " " + x.Model.Type + " " + x.SerialNumber
                })
                .ToListAsync();
        }

        public async Task<ProductDetailsDto> GetDetails(int id)
        {
            return await DbContext.Products
                .Where(x => x.Id == id)
                .Select(x => new ProductDetailsDto
                {
                    Id = x.Id,
                    SerialNumber = x.SerialNumber,
                    AdditionalInf = x.AdditionalInf,
                    ModelId = x.ModelId,
                    Model = x.Model.Manufacturer + " " + x.Model.Type,
                    CustomerId = x.CustomerId,
                    CustomerName = x.Customer.LastName + " " + x.Customer.FirstName
                })
                .SingleOrDefaultAsync();
        }

        public async Task<ProductDto> GetById(int id)
        {
            return await DbContext.Products
                .Where(x => x.Id == id)
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    SerialNumber = x.SerialNumber,
                    AdditionalInf = x.AdditionalInf,
                    ModelId = x.ModelId,
                    CustomerId = x.CustomerId,
                    CustomerName = x.Customer.LastName + " " + x.Customer.FirstName
                })
                .SingleOrDefaultAsync();
        }

        public Task<Product> Get(int id)
        {
            return Get<Product>(id);
        }

        public async Task AddAsync(Product item)
        {
            await Create<Product>(item);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await Get(id);
            if (item != null)
            {
                DbContext.Products.Remove(item);
            }
        }
    }
}
