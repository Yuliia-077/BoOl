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
    //редагувати працівника
    [Authorize(Roles = "Owner, Administrator")]
    public class EditModel : PageModel
    {
        private readonly IRepository<Worker> _repository;
        private readonly IRepository<Position> _repositoryPosition;
        [BindProperty]
        public Worker Worker { get; set; }

        public EditModel(BoOlContext context)
        {
            _repository = new WorkerRepository(context);
            _repositoryPosition = new PositionRepository(context);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Worker = await _repository.GetByIdAsync(Convert.ToInt32(id));

            if (Worker == null)
            {
                return NotFound();
            }

            ViewData["PositionId"] = new SelectList(await _repositoryPosition.SelectAsync(null), "Value", "Text");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.UpdateAsync(Worker);

            return RedirectToPage("./Details", new { id = Worker.Id });
        }
    }
}
