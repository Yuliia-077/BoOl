using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;
using BoOl.Repository;
using Microsoft.AspNetCore.Authorization;

namespace BoOl.Pages.Customers
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IRepository<Customer> _repositoryCustomer;
        private readonly IRepository<Product> _repositoryProduct;
        public IEnumerable<Product> Products { get; set; }
        public int CountOfProducts { get; set; }
        public int CountOfOrders { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public DetailsModel(BoOlContext context)
        {
            _repositoryCustomer = new CustomerRepository(context);
            _repositoryProduct = new ProductRepository(context);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _repositoryCustomer.GetByIdAsync(Convert.ToInt32(id));

            if (Customer == null)
            {
                return NotFound();
            }
            CountOfProducts = await _repositoryProduct.CountAsync(id);
            Products = await _repositoryProduct.GetAllAsync(Customer.Id);

            foreach(var item in Products)
            {
                CountOfOrders += item.Orders.Count();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _repositoryCustomer.DeleteAsync(id);
            return RedirectToPage("./Index");
        }
    }
}
