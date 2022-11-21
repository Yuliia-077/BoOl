using BoOl.Application.Services.Storages;
using BoOl.Models.Storages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Pages.Storages
{
    //перелік постачань на складі
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IStorageService _storageService;
        private readonly int _pageSize = 8;

        public IndexModel(IStorageService storageService)
        {
            _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
        }

        public int CountOfDeliveries { get; set; }
        public IList<StorageListItem> Storages { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public int PageIndex { get; set; }
        public bool ShowPrevious => PageIndex > 1;
        public bool ShowNext => PageIndex < (int)Math.Ceiling(decimal.Divide(CountOfDeliveries, _pageSize));

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

            CountOfDeliveries = await _storageService.Count(searchString);
            var storages = await _storageService.GetListItems(pageIndex, _pageSize, searchString);

            Storages = storages.Select(x => x.AsViewModel()).ToList();
        }
    }
}
