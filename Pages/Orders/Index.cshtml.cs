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
    public class IndexModel : PageModel
    {
        private readonly BoOl.Models.BoOlContext _context;

        public IndexModel(BoOl.Models.BoOlContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task OnGetAsync(int? id)
        {
            if(id!=null)
            {
                Customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
                Order = await _context.Orders
                    .Include(o => o.Product)
                    .Include(o => o.Worker)
                    .Where(o => o.Product.CustomerId == id)
                    .OrderByDescending(o => o.DateOfAdmission)
                    .ToListAsync();
            }
            else
            {
                Order = await _context.Orders
                .Include(o => o.Product)
                .Include(o => o.Worker)
                .OrderByDescending(o => o.DateOfAdmission)
                .ToListAsync();
            }
        }
    }
}
