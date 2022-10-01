using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoOl.Domain;
using BoOl.Repository;
using Microsoft.AspNetCore.Authorization;
using BoOl.Persistence.DatabaseContext;

namespace BoOl.Pages.Types
{
    //редагувати моделі
    [Authorize(Roles = "Owner, Administrator")]
    public class EditModel : PageModel
    {
        private readonly IRepository<Model> _repository;

        [BindProperty]
        public Model Model { get; set; }

        public EditModel(BoOlContext context)
        {
            _repository = new ModelRepository(context);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Model = await _repository.GetByIdAsync(Convert.ToInt32(id));

            if (Model == null)
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

            await _repository.UpdateAsync(Model);

            return RedirectToPage("./Index");
        }
    }
}
