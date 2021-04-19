using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoOl.Models;
using BoOl.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoOl.Pages.CustomServices
{
    public class DetailsModel : PageModel
    {
        private readonly IRepository<CustomService> _repository;
        public int CountOfParts { get; set; }
        public CustomService CustomService { get; set; }

        public DetailsModel(BoOlContext context)
        {
            _repository = new CustomServiceRepository(context);
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
    }
}
