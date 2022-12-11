using BoOl.Application.Services.Positions;
using BoOl.Application.Services.Workers;
using BoOl.Application.Validations.Workers;
using BoOl.Models.Workers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace BoOl.Pages.Workers
{
    //додати працівника
    [Authorize(Roles = "Owner, Administrator")]
    public class CreateModel : PageModel
    {
        private readonly IWorkerService _workerService;
        private readonly IPositionService _positionService;
        private readonly IWorkerValidation _workerValidation;
        [BindProperty]
        public Worker Worker { get; set; }

        public CreateModel(IWorkerService workerService,
            IPositionService positionService,
            IWorkerValidation workerValidation)
        {
            _positionService = positionService;
            _workerService = workerService;
            _workerValidation = workerValidation;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Worker = new Worker();
            Worker.DateOfEmployment = DateTime.Now.Date;
            ViewData["PositionId"] = new SelectList(await _positionService.SelectListOfPositionsAsync(), "Value", "Text");
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

            var id = await _workerService.Create(dto);

            return RedirectToPage("/Workers/Details", new { id = id});
        }
    }
}
