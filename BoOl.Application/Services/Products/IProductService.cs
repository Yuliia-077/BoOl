using BoOl.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoOl.Application.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<SelectListItem>> SelectListOfProductsByCustomerIdAsync(int customerId);
    }
}
