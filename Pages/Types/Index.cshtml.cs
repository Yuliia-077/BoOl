using BoOl.Application.Services.Models;
using BoOl.Models;
using BoOl.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Pages.Types
{
    //перелік всіх моделей
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IModelService _customerService;
        private readonly int _pageSize = 7;

        public IndexModel(IModelService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        public int CountOfModels { get; set; }
        public IList<ModelListItem> Models { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public int PageIndex { get; set; }
        public bool ShowPrevious => PageIndex > 1;
        public bool ShowNext => PageIndex < (int)Math.Ceiling(decimal.Divide(CountOfModels, _pageSize));

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

            CountOfModels = await _customerService.Count(searchString);
            var customers = await _customerService.GetListItems(pageIndex, _pageSize, searchString);

            Models = customers.Select(x => x.AsViewModel()).ToList();
        }

        //public async Task<IActionResult> OnGetDeleteAsync(int id)
        //{
        //    await _repository.DeleteAsync(id);
        //    return RedirectToPage("./Index");
        //}
    }
}
