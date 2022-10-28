using BoOl.Application.Services.Customers;
using BoOl.Models.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Pages.Customers
{
    //перелік усіх клієнтів
    [Authorize(Roles = "Owner, Administrator")]
    public class IndexModel : PageModel
    {
        private readonly ICustomerService _customerService;
        private readonly int _pageSize = 8;

        public IndexModel(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        public int CountOfCustomers { get; set; }
        public IList<CustomerListItem> Customers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public int PageIndex { get; set; }
        public bool ShowPrevious => PageIndex > 1;
        public bool ShowNext => PageIndex < (int)Math.Ceiling(decimal.Divide(CountOfCustomers, _pageSize));

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

            CountOfCustomers = await _customerService.Count(searchString);
            var customers = await _customerService.GetListItems(pageIndex, _pageSize, searchString);

             Customers = customers.Select(x => x.AsViewModel()).ToList();
        }
    }
}
