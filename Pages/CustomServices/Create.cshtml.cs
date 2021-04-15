using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BoOl.Models;
using Microsoft.AspNetCore.Authorization;

namespace BoOl.Pages.CustomServices
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly BoOl.Models.BoOlContext _context;

        public CreateModel(BoOl.Models.BoOlContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Status");
        ViewData["PartId"] = new SelectList(_context.Parts, "Id", "Id");
        ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name");
        ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Address");
            return Page();
        }

        [BindProperty]
        public CustomService CustomService { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CustomServices.Add(CustomService);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
