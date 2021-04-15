using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;
using Microsoft.AspNetCore.Authorization;

namespace BoOl.Pages.Positions
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
        public Models.Position Position { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position = await _context.Positions.FirstOrDefaultAsync(m => m.Id == id);

            if (Position == null)
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

            Position = await _context.Positions.FindAsync(id);

            if (Position != null)
            {
                _context.Positions.Remove(Position);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
