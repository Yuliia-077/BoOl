using BoOl.Application.Services.Customers;
using BoOl.Models;
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
        public int TotalPages { get; private set; }
        public IList<CustomerListItem> Customers { get; set; }

        [BindProperty(SupportsGet = true)]
        public ListQuery Query { get; set; }

        public async Task OnGetAsync()
        {
            if (Query.CurrentPage == default(int))
            {
                Query.CurrentPage = 1;
            }

            CountOfCustomers = await _customerService.Count(Query.Filter);
            TotalPages = (int)Math.Ceiling(decimal.Divide(CountOfCustomers, _pageSize));
            var customers = await _customerService.GetListItems(Query.CurrentPage, _pageSize, Query.Filter);

            Customers = customers.Select(x => x.AsViewModel()).ToList();
        }
    }
}
