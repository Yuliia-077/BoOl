using BoOl.Application.Services.Orders;
using BoOl.Models;
using BoOl.Models.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace BoOl.Pages.Orders
{
    //повна інформація по замовленню
    [Authorize(Roles = "Owner, Administrator, Technician")]
    public class DetailsModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly int _pageSize = 4;

        public DetailsModel(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        public int TotalPages { get; private set; }
        public OrderDetails Order { get; set; }

        [BindProperty(SupportsGet = true)]
        public ListQuery Query { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (Query.CurrentPage == default(int))
            {
                Query.CurrentPage = 1;
            }

            var item = await _orderService.GetDetails(id.Value, Query.CurrentPage, _pageSize);

            if (item == null)
            {
                return NotFound();
            }

            TotalPages = (int)Math.Ceiling(decimal.Divide(item.CountCustomServices, _pageSize));
            Order = item.AsViewModel();
            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            await _orderService.Delete(id);
            return RedirectToPage("./Index");
        }
    }
}
