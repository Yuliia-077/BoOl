using BoOl.Application.Services.Orders;
using BoOl.Models;
using BoOl.Models.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.Pages.Orders
{
    //перелік усіх замовлень
    [Authorize(Roles = "Owner, Administrator, Technician")]
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly int _pageSize = 7;

        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        public int CountOfOrders { get; set; }
        public int TotalPages { get; private set; }
        public IList<OrderListItem> Orders { get; set; }

        [BindProperty(SupportsGet = true)]
        public ListQuery Query { get; set; }

        public async Task OnGetAsync()
        {
            if (Query.CurrentPage == default(int))
            {
                Query.CurrentPage = 1;
            }

            CountOfOrders = await _orderService.Count(Query.Filter);
            var orders = await _orderService.GetList(Query.CurrentPage, _pageSize, Query.Filter);

            TotalPages = (int)Math.Ceiling(decimal.Divide(CountOfOrders, _pageSize));
            Orders = orders.Select(x => x.AsViewModel()).ToList();
        }
    }
}
