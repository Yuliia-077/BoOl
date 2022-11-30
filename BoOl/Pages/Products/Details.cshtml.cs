using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Domain;
using BoOl.Repository;
using Microsoft.AspNetCore.Authorization;
using BoOl.Persistence.DatabaseContext;

namespace BoOl.Pages.Products
{
    //повна інформація по техніці
    [Authorize(Roles = "Owner, Administrator")]
    public class DetailsModel : PageModel
    {
        private readonly IRepository<Product> _repository;
        public int CountOfOrders { get; set; }

        public DetailsModel(BoOlContext context)
        {
            _repository = new ProductRepository(context);
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _repository.GetByIdAsync(Convert.ToInt32(id));
            CountOfOrders = Product.Orders.Count();

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            Product = await _repository.GetByIdAsync(Convert.ToInt32(id));

            await _repository.DeleteAsync(id);
            return RedirectToPage("/Customers/Details", new { id = Product.CustomerId });
        }
    }
}
