using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;

namespace BoOl.Pages.Storages
{
    public class DetailsModel : PageModel
    {
        private readonly BoOl.Models.BoOlContext _context;

        public DetailsModel(BoOl.Models.BoOlContext context)
        {
            _context = context;
        }

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
    }
}
