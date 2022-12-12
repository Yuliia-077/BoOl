using BoOl.Application.Interfaces;
using BoOl.Application.Models.CustomServices;
using BoOl.Application.Models.Orders;
using BoOl.Application.Shared;
using BoOl.Domain;
using BoOl.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Persistence.Repositories
{
    //отримання даних з бд по таблиці замовлення
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(IOptions<DatabaseOptions> databaseOptions, BoOlContext context) : base(databaseOptions, context) { }

        public async Task<bool> Exist(int id)
        {
            return await DbContext.Orders
                .AnyAsync(x => x.Id == id);
        }
        
        public async Task<bool> ExistForCustomerId(int customerId)
        {
            return await DbContext.Orders
                .AnyAsync(x => x.Product.CustomerId == customerId);
        }
        
        public async Task<bool> ExistForWorkerId(int workerId)
        {
            return await DbContext.Orders
                .AnyAsync(x => x.WorkerId == workerId);
        }
        
        public async Task<bool> ExistForProductId(int productId)
        {
            return await DbContext.Orders
                .AnyAsync(x => x.ProductId == productId);
        }
        
        public async Task<bool> ExistActiveForProductId(int productId)
        {
            return await DbContext.Orders
                .AnyAsync(x => x.ProductId == productId && x.Status != Status.Complete);
        }

        public async Task<bool> HasCustomServices(int id)
        {
            return await DbContext.Orders
                .AnyAsync(x => x.Id == id && x.CustomServices.Count() > 0);
        }
        
        public async Task<bool> NotAllCustomServicesCompleted(int id)
        {
            return await DbContext.Orders
                .AnyAsync(x => x.Id == id && x.CustomServices.Any(y => y.IsDone == false));
        }

        public async Task<int> Count(string searchString, int? customerId = null, int? productId = null, int? workerId = null)
        {
            return await (
                    from o in DbContext.Orders
                    join m in DbContext.Models on o.Product.ModelId equals m.Id
                    join c in DbContext.Customers on o.Product.CustomerId equals c.Id
                    where (string.IsNullOrEmpty(searchString) 
                        || (
                            o.Status.Contains(searchString) ||
                            m.Manufacturer.Contains(searchString) ||
                            m.Type.Contains(searchString) ||
                            c.LastName.Contains(searchString) ||
                            c.FirstName.Contains(searchString)
                            ))
                    && (!customerId.HasValue
                        || (
                            c.Id == customerId.Value
                        ))
                    && (!productId.HasValue
                        || (
                            o.ProductId == productId.Value
                        ))
                    && (!workerId.HasValue
                        || (
                            o.WorkerId == workerId.Value
                        ))
                    select o.Id
                    )
                    .CountAsync();
        }

        public async Task<int> CountAllAsync()
        {
            return await DbContext.Orders
                .CountAsync();
        }

        public async Task AddAsync(Order item)
        {
            await Create<Order>(item);
        }

        public async Task Delete(int id)
        {
            var customServices = DbContext.CustomServices.Where(x => x.OrderId == id);
            DbContext.CustomServices.RemoveRange(customServices);

            var order = await DbContext.Orders.SingleOrDefaultAsync(x => x.Id == id);
            DbContext.Orders.Remove(order);
        }

        public Task<Order> Get(int id)
        {
            return Get<Order>(id);
        }

        public async Task<int> GetProductId(int id)
        {
            return await DbContext.Orders
                .Where(x => x.Id == id)
                .Select(x => x.ProductId)
                .FirstOrDefaultAsync();
        }

        public async Task<OrderDto> GetById(int id)
        {
            var item = await DbContext.Orders
                .Where(x => x.Id == id)
                .Select(x => new OrderDto
                {
                    Id = x.Id,
                    DateOfAdmission = x.DateOfAdmission,
                    DateOfIssue = x.DateOfIssue,
                    Discount = x.Discount,
                    Payment = x.Payment,
                    ProductId = x.ProductId,
                    Status = x.Status,
                    CustomerId = x.Product.CustomerId
                }
                )
                .SingleOrDefaultAsync();

            if (item == null)
            {
                return null;
            }

            return item;
        }

        public async Task<OrderDetailsDto> GetDetails(int id)
        {
            return await (
                    from o in DbContext.Orders
                    join m in DbContext.Models on o.Product.ModelId equals m.Id
                    join c in DbContext.Customers on o.Product.CustomerId equals c.Id
                    where o.Id == id
                    orderby o.DateOfAdmission descending
                    select new OrderDetailsDto
                    {
                        Id = o.Id,
                        Payment = o.Payment,
                        Status = o.Status,
                        CustomerId = c.Id,
                        CustomerName = c.LastName + " " + c.FirstName,
                        ProductId = o.Product.Id,
                        ProductModel = m.Manufacturer + " " + m.Type,
                        SerialNumber = o.Product.SerialNumber,
                        WorkerId = o.WorkerId,
                        WorkerName = o.Worker.LastName + " " + o.Worker.FirstName,
                        DateOfAdmission = o.DateOfAdmission,
                        DateOfIssue = o.DateOfIssue,
                        Discount = o.Discount,
                        TotalPrice = o.CustomServices.Sum(x => x.Price),
                        CountCustomServices = o.CustomServices.Count(),
                        CustomServices = (o.CustomServices
                            .OrderByDescending(cs => cs.ExecutionDate)
                            .ThenBy(cs => cs.Id)
                            .Select(cs => new CustomServiceListItemDto
                            {
                                Id = cs.Id,
                                IsDone = cs.IsDone,
                                ExecutionDate = cs.ExecutionDate,
                                WorkerId = cs.WorkerId,
                                WorkerName = cs.Worker.LastName + " " + cs.Worker.FirstName,
                                ServiceId = cs.ServiceId,
                                ServiceName = cs.Service.Name
                            })).ToList()
                    }).SingleOrDefaultAsync();
        }

        public async Task<IList<OrderListItemDto>> GetListAsync(int currentPage, int pageSize, string searchString, int? customerId = null, int? productId = null, int? workerId = null)
        {
            return await (
                    from o in DbContext.Orders
                    join m in DbContext.Models on o.Product.ModelId equals m.Id
                    join c in DbContext.Customers on o.Product.CustomerId equals c.Id
                    where (string.IsNullOrEmpty(searchString)
                    || (
                        o.Status.Contains(searchString) ||
                        m.Manufacturer.Contains(searchString) ||
                        m.Type.Contains(searchString) ||
                        c.LastName.Contains(searchString) ||
                        c.FirstName.Contains(searchString)
                        ))
                    && (!customerId.HasValue
                    || (
                        c.Id == customerId.Value
                    ))
                    && (!productId.HasValue
                    || (
                        o.ProductId == productId.Value
                    ))
                    && (!workerId.HasValue
                    || (
                        o.WorkerId == workerId.Value
                    ))
                    orderby o.DateOfAdmission descending
                    select new
                    {
                        Id = o.Id,
                        Payment = o.Payment,
                        Status = o.Status,
                        CustomerId = c.Id,
                        CustomerName = c.LastName + " " + c.FirstName,
                        ProductId = o.ProductId,
                        ProductModel = m.Manufacturer + " " + m.Type,
                        DateOfAdmission = o.DateOfAdmission

                    })
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .Select(x => new OrderListItemDto
                    {
                        Id = x.Id,
                        Payment = x.Payment,
                        Status = x.Status,
                        CustomerId = x.CustomerId,
                        CustomerName = x.CustomerName,
                        ProductId = x.ProductId,
                        ProductModel = x.ProductModel,
                        DateOfAdmission = x.DateOfAdmission
                    })
                    .ToListAsync();
        }
    }
}
