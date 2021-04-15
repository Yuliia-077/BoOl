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

namespace BoOl.Pages.Positions
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IRepository<Position> _repository;

        public EditModel(BoOlContext context)
        {
            _repository = new PositionRepository(context);
        }

        [BindProperty]
        public Position Position { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position = await _repository.GetByIdAsync(Convert.ToInt32(id));

            if (Position == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.UpdateAsync(Position);

            return RedirectToPage("/Workers/Index");
        }
    }
}
