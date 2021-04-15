using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;
using BoOl.Repository;
using Microsoft.AspNetCore.Authorization;

namespace BoOl.Pages.Services
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IRepository<Service> _repository;

        [BindProperty]
        public Service Service { get; set; }

        public EditModel(BoOlContext context)
        {
            _repository = new ServiceRepository(context);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Service = await _repository.GetByIdAsync(Convert.ToInt32(id));

            if (Service == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.UpdateAsync(Service);

            return RedirectToPage("./Index");
        }
    }
}
