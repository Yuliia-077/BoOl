using BoOl.Application.Services.Services;
using BoOl.Application.Validations.Services;
using BoOl.Models;
using BoOl.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Pages.Services
{
    //перелік усіх послуг
    public class IndexModel : PageModel
    {
        private readonly IServiceService _serviceService;
        private readonly IServiceValidation _serviceValidation;
        private readonly int _pageSize = 7;

        public IndexModel(IServiceService serviceService,
            IServiceValidation serviceValidation)
        {
            _serviceService = serviceService ?? throw new ArgumentNullException(nameof(serviceService));
            _serviceValidation = serviceValidation ?? throw new ArgumentNullException(nameof(serviceValidation));
        }

        public int CountOfServices { get; set; }
        public int TotalPages { get; private set; }
        public IList<ServiceListItem> Services { get; set; }

        [BindProperty(SupportsGet = true)]
        public ListQuery Query { get; set; }

        public async Task OnGetAsync()
        {
            if (Query.CurrentPage == default(int))
            {
                Query.CurrentPage = 1;
            }

            await GetList(Query.CurrentPage, Query.Filter);
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var error = await _serviceValidation.ValidationForDelete(id);
            if (error != null)
            {
                ModelState.AddModelError("All", error);
            }

            if (!ModelState.IsValid)
            {
                await GetList();
                return Page();
            }

            await _serviceService.Delete(id);
            return RedirectToPage("./Index");
        }

        private async Task GetList(int currentPage = 1, string filter = null)
        {
            Query.CurrentPage = currentPage;
            CountOfServices = await _serviceService.Count(filter);
            var services = await _serviceService.GetListItems(currentPage, _pageSize, filter);
            TotalPages = (int)Math.Ceiling(decimal.Divide(CountOfServices, _pageSize));
            Services = services.Select(x => x.AsViewService()).ToList();
        }
    }
}
