using BoOl.Application.Services.Orders;
using BoOl.Application.Services.Products;
using BoOl.Models.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace BoOl.Pages.Orders
{
    //редагування замовлення
    [Authorize(Roles = "Owner, Administrator")]
    public class EditModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public EditModel(IOrderService orderService,
            IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderService.GetById(id.Value);
            Order = order.AsViewModel();

            await GetProductsList();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await GetProductsList();
                return Page();
            }

            await _orderService.Update(Order.AsDto());
            return RedirectToPage("./Details", new {Order.Id});
        }

        private async Task GetProductsList()
        {
            ViewData["ProductId"] = new SelectList(await _productService.SelectListOfProductsByCustomerIdAsync(Order.CustomerId), "Value", "Text");
        }
    }
}
