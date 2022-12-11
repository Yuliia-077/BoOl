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
    //редагувати посаду
    [Authorize(Roles = "Owner, Administrator")]
    public class EditModel : PageModel
    {
        private readonly IPositionService _positionService;
        private readonly IPositionValidation _positionValidation;

        public EditModel(IPositionService positionService,
            IPositionValidation positionValidation)
        {
            _positionService = positionService ?? throw new ArgumentNullException(nameof(positionService));
            _positionValidation = positionValidation ?? throw new ArgumentNullException(nameof(positionValidation));
        }

        [BindProperty]
        public Position Position { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _positionService.GetById(id.Value);

            if (item == null)
            {
                return NotFound();
            }

            Position = item.AsViewModel();

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

            await _positionService.Update(dto);

            return RedirectToPage("/Workers/Index");
        }
    }
}
