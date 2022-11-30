using BoOl.Application.Services.Models;
using BoOl.Application.Validations.Models;
using BoOl.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace BoOl.Pages.Types
{
    //редагувати моделі
    [Authorize(Roles = "Owner, Administrator")]
    public class EditModel : PageModel
    {
        private readonly IModelService _modelService;
        private readonly IModelValidation _modelValidation;

        public EditModel(IModelService modelService,
            IModelValidation modelValidation)
        {
            _modelService = modelService ?? throw new ArgumentNullException(nameof(modelService));
            _modelValidation = modelValidation ?? throw new ArgumentNullException(nameof(modelValidation));
        }

        [BindProperty]
        public Model Model { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound("Id не забезпечено.");
            }

            var dto = await _modelService.GetById(id.Value);

            if (dto == null)
            {
                return NotFound($"Для даного Id = {id} моделі не існує.");
            }
            Model = dto.AsViewModel();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = Model.AsDto();

            var error = await _modelValidation.ValidationForCreateOrUpdate(dto);
            if (error != null)
            {
                ModelState.AddModelError("Model", error);
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _modelService.Update(dto);

            return RedirectToPage("./Index");
        }
    }
}
