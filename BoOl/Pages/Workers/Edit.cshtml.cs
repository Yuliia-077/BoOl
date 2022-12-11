using BoOl.Application.Services.Positions;
using BoOl.Application.Services.Workers;
using BoOl.Application.Validations.Workers;
using BoOl.Models.Workers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace BoOl.Pages.Workers
{
    //редагувати працівника
    [Authorize(Roles = "Owner, Administrator")]
    public class EditModel : PageModel
    {
        private readonly IWorkerService _workerService;
        private readonly IPositionService _positionService;
        private readonly IWorkerValidation _workerValidation;

        public EditModel(IWorkerService workerService,
            IPositionService positionService,
            IWorkerValidation workerValidation)
        {
            _positionService = positionService;
            _workerService = workerService;
            _workerValidation = workerValidation;
        }

        [BindProperty]
        public Worker Worker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound("Id не забезпечено.");
            }

            var dto = await _workerService.GetById(id.Value);
            ViewData["PositionId"] = new SelectList(await _positionService.SelectListOfPositionsAsync(), "Value", "Text");

            if (dto == null)
            {
                return NotFound($"Для даного Id = {id} співробітника не існує.");
            }
            Worker = dto.AsViewModel();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = Worker.AsDto();
            var error = await _workerValidation.ValidationForCreateOrUpdate(dto);

            if (error != null)
            {
                ModelState.AddModelError("Worker", error);
            }

            if (!ModelState.IsValid)
            {
                ViewData["PositionId"] = new SelectList(await _positionService.SelectListOfPositionsAsync(), "Value", "Text");
                return Page();
            }

            await _workerService.Update(Worker.AsDto());

            return RedirectToPage("./Details", new { id = Worker.Id });
        }
    }
}
