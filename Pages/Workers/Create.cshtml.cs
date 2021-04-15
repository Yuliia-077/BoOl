using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;
using BoOl.Repository;
using Microsoft.AspNetCore.Authorization;

namespace BoOl.Pages.Workers
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IRepository<Worker> _repository;
        private readonly IRepository<Position> _repositoryPosition;
        [BindProperty]
        public Worker Worker { get; set; }

        public CreateModel(BoOlContext context)
        {
            _repository = new WorkerRepository(context);
            _repositoryPosition = new PositionRepository(context);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Worker = new Worker();
            Worker.DateOfEmployment = DateTime.Now.Date;
            ViewData["PositionId"] = new SelectList(await _repositoryPosition.SelectAsync(), "Value", "Text");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.AddAsync(Worker);

            return RedirectToPage("/Workers/Details", new { id = Worker.Id});
        }
    }
}
