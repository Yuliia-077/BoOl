using BoOl.Application.Services.CustomServices;
using BoOl.Application.Services.Services;
using BoOl.Application.Validations.CustomServices;
using BoOl.Models.CustomServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace BoOl.Pages.CustomServices
{
    //редагування послуги по замовленню
    [Authorize(Roles = "Owner, Technician")]
    public class EditModel : PageModel
    {
        private readonly ICustomServicesService _customServicesService;
        private readonly IServiceService _serviceService;
        private readonly ICustomServiceValidation _customServicesValidation;

        public EditModel(ICustomServicesService customServicesService,
            IServiceService serviceService,
            ICustomServiceValidation customServicesValidation)
        {
            _customServicesService = customServicesService;
            _serviceService = serviceService;
            _customServicesValidation = customServicesValidation;
        }

        [BindProperty]
        public CustomService CustomService { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _customServicesService.GetById(id.Value);

            if (item == null)
            {
                return NotFound();
            }

            CustomService = item.AsViewModel();
            await GetServices(); 
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = CustomService.AsDto();
            var error = await _customServicesValidation.ValidationForCreateOrUpdate(dto);

            if (error != null)
            {
                ModelState.AddModelError("CustomService", error);
            }

            if (!ModelState.IsValid)
            {
                await GetServices(); 
                return Page();
            }

            await _customServicesService.Update(CustomService.AsDto());

            return RedirectToPage("./Details", new { id = CustomService.Id});
        }

        private async Task GetServices()
        {
            ViewData["ServiceId"] = new SelectList(await _serviceService.Select(), "Value", "Text");
        }
    }
}
