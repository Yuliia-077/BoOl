using BoOl.Application.Services.Services;
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
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IServiceService _serviceService;
        private readonly int _pageSize = 7;

        public IndexModel(IServiceService serviceService)
        {
            _serviceService = serviceService ?? throw new ArgumentNullException(nameof(serviceService));
        }

        public int CountOfServices { get; set; }
        public IList<ServiceListItem> Services { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public int PageIndex { get; set; }
        public bool ShowPrevious => PageIndex > 1;
        public bool ShowNext => PageIndex < (int)Math.Ceiling(decimal.Divide(CountOfServices, _pageSize));

        public async Task OnGetAsync(string currentFilter, int pageIndex = 1, string searchString = null)
        {
            PageIndex = pageIndex;

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            SearchString = searchString;

            CountOfServices = await _serviceService.Count(searchString);
            var services = await _serviceService.GetListItems(pageIndex, _pageSize, searchString);

            Services = services.Select(x => x.AsViewService()).ToList();
        }

        //public async Task<IActionResult> OnGetDeleteAsync(int id)
        //{
        //    await _repository.DeleteAsync(id);
        //    return RedirectToPage("./Index");
        //}
    }
}
