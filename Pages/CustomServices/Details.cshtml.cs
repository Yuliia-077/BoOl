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
    public class DetailsModel : PageModel
    {
        private readonly BoOl.Models.BoOlContext _context;

        public DetailsModel(BoOl.Models.BoOlContext context)
        {
            _context = context;
        }

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
    }
}
