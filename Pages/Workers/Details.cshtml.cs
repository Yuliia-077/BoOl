using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;

namespace BoOl.Pages.Workers
{
    public class DetailsModel : PageModel
    {
        private readonly BoOl.Models.BoOlContext _context;

        public DetailsModel(BoOl.Models.BoOlContext context)
        {
            _context = context;
        }

        public Worker Worker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Worker = await _context.Workers
                .Include(w => w.Position).FirstOrDefaultAsync(m => m.Id == id);

            if (Worker == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
