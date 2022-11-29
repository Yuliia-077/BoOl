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
    //додати моделі
    [Authorize(Roles = "Owner, Administrator")]
    public class CreateModel : PageModel
    {
        private readonly IModelService _modelService;
        private readonly IModelValidation _modelValidation;
        public CreateModel(IModelService modelService,
            IModelValidation modelValidation)
        {
            _modelService = modelService ?? throw new ArgumentNullException(nameof(modelService));
            _modelValidation = modelValidation ?? throw new ArgumentNullException(nameof(modelValidation));
        }

        [BindProperty]
        public Model Model { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = Model.AsDto();

            var error = await _modelValidation.ValidationForCreateOrUpdate(dto);
            if(error != null)
            {
                ModelState.AddModelError("Model", error);
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var modelID = await _modelService.Create(dto);

            return RedirectToPage("./Index");
        }
    }
}
