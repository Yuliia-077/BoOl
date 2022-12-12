using BoOl.Application.Services.Customers;
using BoOl.Application.Services.Orders;
using BoOl.Application.Services.Products;
using BoOl.Application.Shared;
using BoOl.Application.Validations.Orders;
using BoOl.Models.Customers;
using BoOl.Models.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace BoOl.Pages.Orders
{
    //створення замовлення через клієнта
    [Authorize(Roles = "Owner, Administrator")]
    public class CreateModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly IOrderValidation _orderValidation;

        public CreateModel(IOrderService orderService,
            IProductService productService,
            ICustomerService customerService,
            IOrderValidation orderValidation)
        {
            _customerService = customerService;
            _productService = productService;
            _orderService = orderService;
            _orderValidation = orderValidation;
        }

        [BindProperty]
        public Order Order { get; set; }
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await Get(id.Value);

            Order = new Order()
            {
                CustomerId = id.Value,
                Discount = Customer.Discount,
                DateOfAdmission = DateTime.Now.Date,
                Status = Status.Open
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = Order.AsDto();

            var error = await _orderValidation.ValidationForCreate(dto);

            if (error != null)
            {
                ModelState.AddModelError("Order", error);
            }

            if (!ModelState.IsValid)
            {
                await Get(Order.CustomerId);
                return Page();
            }

            var id = await _orderService.Create(dto, User.Identity.Name);

            return RedirectToPage("./Details", new { id = id});
        }

        private async Task Get(int id)
        {
            var item = await _customerService.GetById(id);
            Customer = item.AsViewModel();
            ViewData["ProductId"] = new SelectList(await _productService.SelectListOfProductsByCustomerIdAsync(id), "Value", "Text");
        }
    }
}
