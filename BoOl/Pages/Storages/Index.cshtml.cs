using BoOl.Application.Services.Storages;
using BoOl.Models;
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
        private readonly int _pageSize = 7;

        public IndexModel(IStorageService storageService)
        {
            _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
        }

        public int CountOfDeliveries { get; set; }
        public int TotalPages { get; private set; }
        public IList<StorageListItem> Storages { get; set; }

        [BindProperty(SupportsGet = true)]
        public ListQuery Query { get; set; }

        public async Task OnGetAsync()
        {
            if(Query.CurrentPage == default(int))
            {
                Query.CurrentPage = 1;
            }

            CountOfDeliveries = await _storageService.Count(Query.Filter);
            TotalPages = (int)Math.Ceiling(decimal.Divide(CountOfDeliveries, _pageSize));

            var storages = await _storageService.GetListItems(Query.CurrentPage, _pageSize, Query.Filter);
            Storages = storages.Select(x => x.AsViewModel()).ToList();
        }
    }
}
