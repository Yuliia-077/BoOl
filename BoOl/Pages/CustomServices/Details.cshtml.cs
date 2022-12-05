using BoOl.Application.Services.CustomServices;
using BoOl.Application.Services.Parts;
using BoOl.Models;
using BoOl.Models.CustomServices;
using BoOl.Models.Parts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Pages.CustomServices
{
    //повна інформація по виконаній послузі
    [Authorize(Roles = "Owner, Administrator, Technician")]
    public class DetailsModel : PageModel
    {
        private readonly ICustomServicesService _customServicesService;
        private readonly IPartService _partService;
        private readonly int _pageSize = 3;

        public DetailsModel(ICustomServicesService customServicesService,
            IPartService partService)
        {
            _customServicesService = customServicesService;
            _partService = partService;
        }

        public IList<Part> Parts { get; set; }
        public CustomServiceDetails CustomService { get; set; }
        public int TotalPages { get; private set; }

        [BindProperty(SupportsGet = true)]
        public ListQuery Query { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _customServicesService.GetDetails(id.Value);

            if (item == null)
            {
                return NotFound();
            }

            CustomService = item.AsViewModel();

            if (Query.CurrentPage == default(int))
            {
                Query.CurrentPage = 1;
            }

            var parts = await _partService.GetListAsync(id.Value, Query.CurrentPage, _pageSize);
            TotalPages = (int)Math.Ceiling(decimal.Divide(await _partService.Count(id.Value), _pageSize));

            Parts = parts.Select(x => x.AsViewModel()).ToList();

            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            await _partService.Delete(id);
            return RedirectToPage("/Orders/Details", new { id = CustomService.OrderId});
        }

        public async Task<IActionResult> OnGetDeletePartAsync(int id, int customServiceId)
        {
            await _partService.Delete(id);
            return RedirectToPage("./Details", new { id = customServiceId });
        }
        
        public async Task<IActionResult> OnGetReturnToStorageAsync(int id, int customServiceId)
        {
            await _partService.DeleteWithReturnToStorage(id);
            return RedirectToPage("./Details", new { id = customServiceId });
        }
    }
}
