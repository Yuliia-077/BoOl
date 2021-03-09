using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BoOl.Models;

namespace BoOl.Pages.Workers
{
    public class CreateModel : PageModel
    {
        private readonly BoOl.Models.BoOlContext _context;

        public CreateModel(BoOl.Models.BoOlContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Worker Worker { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Workers.Add(Worker);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
