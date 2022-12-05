using BoOl.Application.Services.CustomServices;
using BoOl.Application.Services.Services;
using BoOl.Models.CustomServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace BoOl.Pages.CustomServices
{
    //створення послуги по замовленню
    [Authorize(Roles = "Owner, Technician")]
    public class CreateModel : PageModel
    {
        private readonly ICustomServicesService _customServicesService;
        private readonly IServiceService _serviceService;

        public CreateModel(ICustomServicesService customServicesService,
            IServiceService serviceService)
        {
            _customServicesService = customServicesService;
            _serviceService = serviceService;
        }

        [BindProperty]
        public CustomService CustomService { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {

                return NotFound();
            }
            CustomService = new CustomService();
            CustomService.OrderId = id.Value;
            CustomService.ExecutionDate = DateTime.Now.Date;

            await GetServices();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await GetServices();
                return Page();
            }

            var id = await _customServicesService.Create(CustomService.AsDto(), User.Identity.Name);

            return RedirectToPage("./Details", new { id = id });
        }

        private async Task GetServices()
        {
            ViewData["ServiceId"] = new SelectList(await _serviceService.Select(), "Value", "Text");
        }
    }
}
