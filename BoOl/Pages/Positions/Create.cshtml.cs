using BoOl.Application.Services.Positions;
using BoOl.Application.Validations.Positions;
using BoOl.Models.Positions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace BoOl.Pages.Positions
{
    //створити нову посаду
    [Authorize(Roles = "Owner, Administrator")]
    public class CreateModel : PageModel
    {
        private readonly IPositionService _positionService;
        private readonly IPositionValidation _positionValidation;

        public CreateModel(IPositionService positionService,
            IPositionValidation positionValidation)
        {
            _positionService = positionService ?? throw new ArgumentNullException(nameof(positionService));
            _positionValidation = positionValidation ?? throw new ArgumentNullException(nameof(positionValidation));
        }

        [BindProperty]
        public Position Position { get; set; }

        public IActionResult OnGet()
        {
            Position = new Position();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = Position.AsDto();

            var error = await _positionValidation.ValidationForCreateOrUpdate(dto);
            if (error != null)
            {
                ModelState.AddModelError("Position", error);
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _positionService.Create(dto);

            return RedirectToPage("/Workers/Index");
        }
    }
}
