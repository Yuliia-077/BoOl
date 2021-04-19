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
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IRepository<Storage> _repository;
        private readonly IRepository<Model> _repositoryModel;
        private readonly UserRepository _repositoryUser;
        [BindProperty]
        public Storage Storage { get; set; }

        public CreateModel(BoOlContext context)
        {
            _repository = new StorageRepository(context);
            _repositoryModel = new ModelRepository(context);
            _repositoryUser = new UserRepository(context);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Storage = new Storage();
            Storage.DateOfArrival = DateTime.Now;
            var user = await _repositoryUser.GetByIdAsync(User.Identity.Name);
            Storage.WorkerId = user.WorkerId;
            ViewData["ModelId"] = new SelectList(await _repositoryModel.SelectAsync(null), "Value", "Text");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.AddAsync(Storage);

            return RedirectToPage("./Details", new { id = Storage.Id });
        }
    }
}
