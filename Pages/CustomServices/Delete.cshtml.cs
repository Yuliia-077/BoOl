using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;

namespace BoOl.Pages.CustomServices
{
    public class DeleteModel : PageModel
    {
        private readonly BoOl.Models.BoOlContext _context;

        public DeleteModel(BoOl.Models.BoOlContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomService = await _context.CustomServices.FindAsync(id);

            if (CustomService != null)
            {
                _context.CustomServices.Remove(CustomService);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
