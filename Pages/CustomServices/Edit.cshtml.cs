using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;
using Microsoft.AspNetCore.Authorization;

namespace BoOl.Pages.CustomServices
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly BoOl.Models.BoOlContext _context;

        public EditModel(BoOl.Models.BoOlContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomService CustomService { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomService = await _context.CustomServices
                .Include(c => c.Order)
                .Include(c => c.Part)
                .Include(c => c.Service)
                .Include(c => c.Worker).FirstOrDefaultAsync(m => m.Id == id);

            if (CustomService == null)
            {
                return NotFound();
            }
           ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Status");
           ViewData["PartId"] = new SelectList(_context.Parts, "Id", "Id");
           ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name");
           ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Address");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CustomService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomServiceExists(CustomService.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomServiceExists(int id)
        {
            return _context.CustomServices.Any(e => e.Id == id);
        }
    }
}
