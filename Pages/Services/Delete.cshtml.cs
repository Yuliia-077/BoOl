using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;
using Microsoft.AspNetCore.Authorization;

namespace BoOl.Pages.Services
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly BoOl.Models.BoOlContext _context;

        public DeleteModel(BoOl.Models.BoOlContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Service Service { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Service = await _context.Services.FirstOrDefaultAsync(m => m.Id == id);

            if (Service == null)
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

            Service = await _context.Services.FindAsync(id);

            if (Service != null)
            {
                _context.Services.Remove(Service);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
