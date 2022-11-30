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
    //редагувати послугу
    [Authorize(Roles = "Owner, Administrator")]
    public class EditModel : PageModel
    {
        private readonly IServiceService _serviceService;
        private readonly IServiceValidation _serviceValidation;

        public EditModel(IServiceService serviceService,
            IServiceValidation serviceValidation)
        {
            _serviceService = serviceService ?? throw new ArgumentNullException(nameof(serviceService));
            _serviceValidation = serviceValidation ?? throw new ArgumentNullException(nameof(serviceValidation));
        }

        [BindProperty]
        public Service Service { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound("Id не забезпечено.");
            }

            var dto = await _serviceService.GetById(id.Value);

            if (dto == null)
            {
                return NotFound($"Для даного Id = {id} моделі не існує.");
            }
            Service = dto.AsViewModel();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = Service.AsDto();

            var errorMessage = await _serviceValidation.ValidationForCreateOrUpdate(dto);
            if (errorMessage != null)
            {
                ModelState.AddModelError("Service", errorMessage);
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _serviceService.Update(dto);

            return RedirectToPage("./Index");
        }
    }
}
