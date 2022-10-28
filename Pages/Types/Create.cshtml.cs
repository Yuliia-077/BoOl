using BoOl.Application.Services.Models;
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
        public CreateModel(IModelService modelService)
        {
            _modelService = modelService ?? throw new ArgumentNullException(nameof(modelService));
        }

        [BindProperty]
        public Model Model { get; set; }

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

            var modelID = await _modelService.Create(Model.AsDto());

            return RedirectToPage("./Index");
        }
    }
}
