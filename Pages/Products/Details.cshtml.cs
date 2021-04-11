using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;
using BoOl.Repository;

namespace BoOl.Pages.Products
{
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
    }
}
