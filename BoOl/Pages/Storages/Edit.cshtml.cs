using BoOl.Application.Services.Models;
using BoOl.Application.Services.Storages;
using BoOl.Application.Validations.Services;
using BoOl.Models.Storages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace BoOl.Pages.Storages
{
    //редагувати постачання
    [Authorize(Roles = "Owner, Storekeeper")]
    public class EditModel : PageModel
    {
        private readonly IStorageService _storageService;
        private readonly IModelService _modelService;
        private readonly IStorageValidation _storageValidation;

        [BindProperty]
        public Storage Storage { get; set; }

        public EditModel(IStorageService storageService,
            IModelService modelService,
            IStorageValidation storageValidation)
        {
            _modelService = modelService;
            _storageService = storageService;
            _storageValidation = storageValidation;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await Get(id.Value);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = Storage.AsDto();
            var error = await _storageValidation.ValidationForCreateOrUpdate(dto);
            if (error != null)
            {
                ModelState.AddModelError("Storage", error);
            }

            if (!ModelState.IsValid)
            {
                await Get(Storage.Id.Value);
                return Page();
            }

            await _storageService.Update(dto);

            return RedirectToPage("./Details", new { id = Storage.Id });
        }

        private async Task Get(int id)
        {
            var storage = await _storageService.GetById(id);
            Storage = storage.AsViewModel();
            ViewData["ModelId"] = new SelectList(await _modelService.SelectListOfModelsAsync(), "Value", "Text");
        }
    }
}
