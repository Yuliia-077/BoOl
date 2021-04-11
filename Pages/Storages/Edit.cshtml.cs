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
    public class EditModel : PageModel
    {
        private readonly BoOl.Models.BoOlContext _context;

        public EditModel(BoOl.Models.BoOlContext context)
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
            var workers = _context.Workers.Select(
                x => new { Value = x.Id, Text = x.LastName + " " + x.FirstName }).ToList();
            var models = _context.Models.Select(
               x => new { Value = x.Id, Text = x.Manufacturer + " " + x.Type }).ToList();
            ViewData["ModelId"] = new SelectList(models, "Value", "Text");
            ViewData["WorkerId"] = new SelectList(workers, "Value", "Text");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Storage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StorageExists(Storage.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StorageExists(int id)
        {
            return _context.Storages.Any(e => e.Id == id);
        }
    }
}
