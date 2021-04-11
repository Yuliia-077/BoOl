using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;

namespace BoOl.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly BoOl.Models.BoOlContext _context;

        public EditModel(BoOl.Models.BoOlContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }
        [BindProperty]
        public int CustomerId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders
                .Include(o => o.Product)
                .Include(o => o.Worker).FirstOrDefaultAsync(m => m.Id == id);
            CustomerId = Order.Product.CustomerId;

            if (Order == null)
            {
                return NotFound();
            }
            await OnGetLists(CustomerId);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetLists(CustomerId);
                return Page();
            }

            _context.Attach(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index", new {id = CustomerId});
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }

        public async Task OnGetLists(int? id)
        {
            if (id != null)
            {
                var workers = await _context.Workers
                    .Select(x => new { Value = x.Id, Text = x.LastName + " " + x.FirstName })
                    .ToListAsync();
                var products = await _context.Products
                    .Where(x => x.CustomerId == id)
                    .Select(x => new { Value = x.Id, Text = x.SerialNumber + " " + x.Model.Manufacturer + " " + x.Model.Type })
                    .ToListAsync();
                ViewData["WorkerId"] = new SelectList(workers, "Value", "Text");
                ViewData["ProductId"] = new SelectList(products, "Value", "Text");
            }
        }
    }
}
