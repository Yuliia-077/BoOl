using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BoOl.Domain;
using BoOl.Repository;
using Microsoft.AspNetCore.Authorization;
using BoOl.Persistence.DatabaseContext;

namespace BoOl.Pages.Services
{
    //додати нову послугу
    [Authorize(Roles = "Owner, Administrator")]
    public class CreateModel : PageModel
    {
        private readonly IRepository<Service> _repository;

        [BindProperty]
        public Service Service { get; set; }

        public CreateModel(BoOlContext context)
        {
            _repository = new ServiceRepository(context);
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.AddAsync(Service);

            return RedirectToPage("./Index");
        }
    }
}
