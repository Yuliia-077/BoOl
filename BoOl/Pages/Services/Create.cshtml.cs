using BoOl.Application.Services.Services;
using BoOl.Application.Validations.Services;
using BoOl.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace BoOl.Pages.Services
{
    //додати нову послугу
    [Authorize(Roles = "Owner, Administrator")]
    public class CreateModel : PageModel
    {
        private readonly IServiceService _serviceService;
        private readonly IServiceValidation _serviceValidation;

        public CreateModel(IServiceService serviceService,
            IServiceValidation serviceValidation)
        {
            _serviceService = serviceService ?? throw new ArgumentNullException(nameof(serviceService));
            _serviceValidation = serviceValidation ?? throw new ArgumentNullException(nameof(serviceValidation));
        }

        [BindProperty]
        public Service Service { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = Service.AsDto();

            var errorMessage = await _serviceValidation.ValidationForCreateOrUpdate(dto);
            if(errorMessage != null)
            {
                ModelState.AddModelError("Service", errorMessage);
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var serviceID = await _serviceService.Create(dto);

            return RedirectToPage("./Index");
        }
    }
}
