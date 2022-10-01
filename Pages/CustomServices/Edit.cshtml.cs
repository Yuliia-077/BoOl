using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoOl.Domain;
using Microsoft.AspNetCore.Authorization;
using BoOl.Repository;
using BoOl.Persistence.DatabaseContext;

namespace BoOl.Pages.CustomServices
{
    //редагування послуги по замовленню
    [Authorize(Roles = "Owner, Technician")]
    public class EditModel : PageModel
    {
        private readonly IRepository<CustomService> _repository;
        private readonly IRepository<Service> _repositoryService;
        [BindProperty]
        public CustomService CustomService { get; set; }

        public EditModel(BoOlContext context)
        {
            _repository = new CustomServiceRepository(context);
            _repositoryService = new ServiceRepository(context);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomService = await _repository.GetByIdAsync(Convert.ToInt32(id));

            if (CustomService == null)
            {
                return NotFound();
            }
            ViewData["ServiceId"] = new SelectList(await _repositoryService.SelectAsync(null), "Value", "Text");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ServiceId"] = new SelectList(await _repositoryService.SelectAsync(null), "Value", "Text");
                return Page();
            }

            await _repository.UpdateAsync(CustomService);

            return RedirectToPage("./Details", new { id = CustomService.Id});
        }
    }
}
