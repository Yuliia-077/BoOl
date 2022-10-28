using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoOl.Repository;
using Microsoft.AspNetCore.Authorization;
using BoOl.Persistence.DatabaseContext;
using BoOl.Application.Services.Models;
using BoOl.Models;
using BoOl.Models.Models;

namespace BoOl.Pages.Types
{
    //редагувати моделі
    [Authorize(Roles = "Owner, Administrator")]
    public class EditModel : PageModel
    {
        private readonly IModelService _modelService;

        public EditModel(IModelService modelService)
        {
            _modelService = modelService ?? throw new ArgumentNullException(nameof(modelService));
        }

        [BindProperty]
        public Model Model { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound("Id не забезпечено.");
            }

            var dto = await _modelService.GetById(Convert.ToInt32(id));

            if (dto == null)
            {
                return NotFound($"Для даного Id = {id} моделі не існує.");
            }
            Model = dto.AsViewModel();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _modelService.Update(Model.AsDto());

            return RedirectToPage("./Index");
        }
    }
}
