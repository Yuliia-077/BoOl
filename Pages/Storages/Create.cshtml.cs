using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;

namespace BoOl.Pages.Storages
{
    public class CreateModel : PageModel
    {
        private readonly BoOl.Models.BoOlContext _context;

        public CreateModel(BoOl.Models.BoOlContext context)
        {
            _context = context;
        }

        public IActionResult OnGetAsync()
        {
            var workers = _context.Workers.Select(
                x => new { Value = x.Id, Text = x.LastName +" " + x.FirstName}).ToList();
            var models = _context.Models.Select(
               x => new { Value = x.Id, Text = x.Manufacturer + " " + x.Type }).ToList();
            ViewData["ModelId"] = new SelectList(models, "Value", "Text");
            ViewData["WorkerId"] = new SelectList(workers, "Value", "Text");
            return Page();
        }

        [BindProperty]
        public Storage Storage { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Storages.Add(Storage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
