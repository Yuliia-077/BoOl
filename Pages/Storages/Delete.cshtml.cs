using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;
using Microsoft.AspNetCore.Authorization;

namespace BoOl.Pages.Storages
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
        public Storage Storage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Storage = await _context.Storages
                .Include(s => s.Model)
                .Include(s => s.Worker).FirstOrDefaultAsync(m => m.Id == id);

            if (Storage == null)
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

            Storage = await _context.Storages.FindAsync(id);

            if (Storage != null)
            {
                _context.Storages.Remove(Storage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
