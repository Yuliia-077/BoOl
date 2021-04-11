using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BoOl.Models;
using Microsoft.EntityFrameworkCore;

namespace BoOl.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly BoOl.Models.BoOlContext _context;

        [BindProperty]
        public Order Order { get; set; }
        [BindProperty]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public CreateModel(BoOl.Models.BoOlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {

                return NotFound();
            }
            CustomerId = Convert.ToInt32(id);
            Order = new Order();
            Customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            Order.Discount = Customer.Discount;
            Order.DateOfAdmission = DateTime.Now.Date;
            await OnGetLists(id);
            //var workers = _context.Workers.Select(
            //x => new { Value = x.Id, Text = x.LastName + " " + x.FirstName }).ToList();
            //var products = _context.Products
            //    .Where(x=> x.CustomerId == id)
            //    .Select(
            //    x => new { Value = x.Id, Text = x.SerialNumber + " " + x.Model.Manufacturer + " " + x.Model.Type }).ToList();
            //ViewData["WorkerId"] = new SelectList(workers, "Value", "Text");
            //ViewData["ProductId"] = new SelectList(products, "Value", "Text");
            //ViewData["ProductId"] = new SelectList(_context.Products, "Id", "SerialNumber");
            //ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Address");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == CustomerId);
                await OnGetLists(CustomerId);
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = CustomerId});
        }

        public async Task OnGetLists(int? id)
        {
            if(id != null)
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
