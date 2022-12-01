using BoOl.Application.Services.Models;
using BoOl.Application.Services.Storages;
using BoOl.Application.Validations.Services;
using BoOl.Models.Storages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace BoOl.Pages.Storages
{
    //додати постачання
    [Authorize(Roles = "Owner, Storekeeper")]
    public class CreateModel : PageModel
    {
        private readonly IStorageService _storageService;
        private readonly IModelService _modelService;
        private readonly IStorageValidation _storageValidation;

        [BindProperty]
        public Storage Storage { get; set; }

        public CreateModel(IStorageService storageService,
            IModelService modelService,
            IStorageValidation storageValidation)
        {
            _modelService = modelService;
            _storageService = storageService;
            _storageValidation = storageValidation;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await Get();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = Storage.AsDto();
            var error = await _storageValidation.ValidationForCreateOrUpdate(dto);
            if(error != null)
            {
                ModelState.AddModelError("Storage", error);
            }

            if (!ModelState.IsValid)
            {
                await Get();
                return Page();
            }

            var id = await _storageService.Create(dto, User.Identity.Name);

            return RedirectToPage("./Details", new { id = id });
        }

        private async Task Get()
        {
            Storage = new Storage();
            Storage.DateOfArrival = DateTime.Now;
            ViewData["ModelId"] = new SelectList(await _modelService.SelectListOfModelsAsync(), "Value", "Text");
        }
    }
}
