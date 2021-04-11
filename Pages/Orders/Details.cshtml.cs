using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;

namespace BoOl.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly BoOl.Models.BoOlContext _context;

        public Order Order { get; set; }
        public int CustomerId { get; set; }

        public DetailsModel(BoOl.Models.BoOlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders
                .Include(o => o.Worker)
                .Include(o => o.Product)
                .Include(o => o.Product.Model)
                .FirstOrDefaultAsync(m => m.Id == id);

            CustomerId = Order.Product.CustomerId;

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
