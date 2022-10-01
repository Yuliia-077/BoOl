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

namespace BoOl.Pages.Parts
{
    //додає нову запчастину з складу
    [Authorize(Roles = "Owner, Technician")]
    public class CreateModel : PageModel
    {
        private readonly IRepository<Part> _repository;
        private readonly IRepository<CustomService> _repositoryCustom;
        private readonly IRepository<Storage> _repositoryStorage;
        public CustomService CustomService { get; set; }
        [BindProperty]
        public Part Part { get; set; }

        public CreateModel(BoOlContext context)
        {
            _repository = new PartRepository(context);
            _repositoryCustom = new CustomServiceRepository(context);
            _repositoryStorage = new StorageRepository(context);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Part = new Part();
            var custom = await _repositoryCustom.GetByIdAsync(Convert.ToInt32(id));
            CustomService = custom;

            Part.CustomService = custom;
            Part.CustomServiceId = custom.Id;

            ViewData["StorageId"] = new SelectList(await _repositoryStorage.SelectAsync(null), "Value", "Text");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.AddAsync(Part);

            return RedirectToPage("/CustomServices/Details", new { id = Part.CustomServiceId});
        }
    }
}
