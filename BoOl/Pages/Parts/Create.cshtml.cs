﻿using BoOl.Application.Services.Parts;
using BoOl.Application.Services.Storages;
using BoOl.Application.Validations.Parts;
using BoOl.Models.Parts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace BoOl.Pages.Parts
{
    //додає нову запчастину з складу
    [Authorize(Roles = "Owner, Technician")]
    public class CreateModel : PageModel
    {
        private readonly IPartService _partService;
        private readonly IStorageService _storageService;
        private readonly IPartValidation _partValidation;

        [BindProperty]
        public Part Part { get; set; }

        public CreateModel(IPartService partService,
            IStorageService storageService,
            IPartValidation partValidation)
        {
            _partService = partService;
            _storageService = storageService;
            _partValidation = partValidation;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Part = new Part();
            Part.CustomServiceId = id.Value;

            ViewData["StorageId"] = new SelectList(await _storageService.SelectAsync(), "Value", "Text");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = Part.AsDto();
            var error = await _partValidation.ValidationForCreateOrUpdate(dto);

            if (error != null)
            {
                ModelState.AddModelError("", error);
            }
            if (!ModelState.IsValid)
            {
                ViewData["StorageId"] = new SelectList(await _storageService.SelectAsync(), "Value", "Text");
                return Page();
            }

            await _partService.Create(Part.AsDto());

            return RedirectToPage("/CustomServices/Details", new { id = Part.CustomServiceId});
        }
    }
}
