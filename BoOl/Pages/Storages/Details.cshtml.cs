using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Domain;
using Microsoft.AspNetCore.Authorization;
using BoOl.Repository;
using BoOl.Persistence.DatabaseContext;
using BoOl.Models.Storages;
using BoOl.Application.Services.Storages;
using BoOl.Application.Validations.Services;

namespace BoOl.Pages.Storages
{
    //повна інформація по постачанню
    [Authorize(Roles = "Owner, Administrator, Technician,  Storekeeper")]
    public class DetailsModel : PageModel
    {
        private readonly IStorageService _storageService;
        private readonly IStorageValidation _storageValidation;

        public DetailsModel(IStorageService storageService,
            IStorageValidation storageValidation)
        {
            _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
            _storageValidation = storageValidation ?? throw new ArgumentNullException(nameof(storageValidation));
        }

        public StorageDetails Storage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storage = await _storageService.GetDetails(id.Value);

            Storage = storage.AsViewModel();
            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var error = await _storageValidation.ValidationForDelete(id);

            if(error != null)
            {
                ModelState.AddModelError("All", error);
            }

            if(!ModelState.IsValid)
            {
                var storage = await _storageService.GetDetails(id);
                Storage = storage.AsViewModel();
                return Page();
            }

            await _storageService.Delete(id);
            return RedirectToPage("./Index");
        }
    }
}
