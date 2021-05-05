using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;
using Microsoft.AspNetCore.Authorization;
using BoOl.Repository;

namespace BoOl.Pages.Storages
{
    //редагувати постачання
    [Authorize(Roles = "Owner, Storekeeper")]
    public class EditModel : PageModel
    {
        private readonly IRepository<Storage> _repository;
        private readonly IRepository<Model> _repositoryModel;
        [BindProperty]
        public Storage Storage { get; set; }

        public EditModel(BoOlContext context)
        {
            _repository = new StorageRepository(context);
            _repositoryModel = new ModelRepository(context);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Storage = await _repository.GetByIdAsync(Convert.ToInt32(id));

            if (Storage == null)
            {
                return NotFound();
            }

            ViewData["ModelId"] = new SelectList(await _repositoryModel.SelectAsync(null), "Value", "Text");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.UpdateAsync(Storage);

            return RedirectToPage("./Details", new { id = Storage.Id });
        }
    }
}
