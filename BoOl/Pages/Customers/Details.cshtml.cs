using BoOl.Application.Services.Customers;
using BoOl.Application.Validations.Customers;
using BoOl.Models.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace BoOl.Pages.Customers
{
    //повна інформація по клієнту
    [Authorize(Roles = "Owner, Administrator")]
    public class DetailsModel : PageModel
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerValidation _customerValidation;
        private readonly int _pageSize = 3;

        public DetailsModel(ICustomerService customerService,
            ICustomerValidation customerValidation)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _customerValidation = customerValidation ?? throw new ArgumentNullException(nameof(customerValidation));
        }

        public CustomerDetails Customer { get; set; }
        public int OrdersTotalPages { get; private set; }
        public int ProductsTotalPages { get; private set; }

        [BindProperty(SupportsGet = true)]
        public int OrdersCurrentPage { get; set; }
        [BindProperty(SupportsGet = true)]
        public int ProductsCurrentPage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await Get(id.Value);

            if (Customer == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var error = await _customerValidation.ValidationForDelete(id);

            if (error != null)
            {
                ModelState.AddModelError("Customer", error);
            }

            if (!ModelState.IsValid)
            {
                await Get(id);
                return Page();
            }

            await _customerService.Delete(id);

            return RedirectToPage("./Index");
        }

        private async Task Get(int id)
        {
            if (OrdersCurrentPage == default(int))
            {
                OrdersCurrentPage = 1;
            }
            
            if (ProductsCurrentPage == default(int))
            {
                ProductsCurrentPage = 1;
            }

            var item = await _customerService.GetDetails(id, OrdersCurrentPage, ProductsCurrentPage, _pageSize);

            ProductsTotalPages = (int)Math.Ceiling(decimal.Divide(item.CountOfProducts, _pageSize));
            OrdersTotalPages = (int)Math.Ceiling(decimal.Divide(item.CountOfOrders, _pageSize));

            Customer = item.AsViewModel();
        }
    }
}
