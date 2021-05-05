using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoOl.Models;
using BoOl.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoOl.Pages.CustomServices
{
    //повна інформація по виконаній послузі
    [Authorize(Roles = "Owner, Administrator, Technician")]
    public class DetailsModel : PageModel
    {
        private readonly IRepository<CustomService> _repository;
        private readonly IRepository<Part> _partsRepository;
        public int CountOfParts { get; set; }
        public CustomService CustomService { get; set; }

        public DetailsModel(BoOlContext context)
        {
            _repository = new CustomServiceRepository(context);
            _partsRepository = new PartRepository(context);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomService = await _repository.GetByIdAsync(Convert.ToInt32(id));
            CountOfParts = CustomService.Parts.Count();

            if (CustomService == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            CustomService = await _repository.GetByIdAsync(Convert.ToInt32(id));

            await _repository.DeleteAsync(id);
            return RedirectToPage("/Orders/Details", new { id = CustomService.OrderId});
        }

        public async Task<IActionResult> OnGetDeletePartAsync(int id)
        {
            CustomService = await _repository.GetByIdAsync(Convert.ToInt32(id));

            await _partsRepository.DeleteAsync(id);
            return RedirectToPage("./Details", new { id = CustomService.Id });
        }
    }
}
