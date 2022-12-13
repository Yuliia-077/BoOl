using BoOl.Application.Services.Products;
using BoOl.Application.Validations.Products;
using BoOl.Models;
using BoOl.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace BoOl.Pages.Products
{
    //повна інформація по техніці
    [Authorize(Roles = "Owner, Administrator")]
    public class DetailsModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductValidation _productValidation;
        private readonly int _pageSize = 3;

        public DetailsModel(IProductService productService, IProductValidation productValidation)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _productValidation = productValidation ?? throw new ArgumentNullException(nameof(productValidation));
        }

        public int TotalPages { get; private set; }
        public ProductDetails Product { get; set; }

        [BindProperty(SupportsGet = true)]
        public ListQuery Query { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await Get(id.Value);
            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id, int customerId)
        {
            var error = await _productValidation.ValidationForDelete(id);

            if (error != null)
            {
                ModelState.AddModelError("Product", error);
            }

            if (!ModelState.IsValid)
            {
                await Get(id);
                return Page();
            }

            await _productService.Delete(id);

            return RedirectToPage("/Customers/Details", new { id = customerId });
        }

        private async Task Get(int id)
        {
            if (Query.CurrentPage == default(int))
            {
                Query.CurrentPage = 1;
            }

            var item = await _productService.GetDetails(id, Query.CurrentPage, _pageSize);

            TotalPages = (int)Math.Ceiling(decimal.Divide(item.CountOfOrders, _pageSize));
            Product = item.AsViewModel();
        }
    }
}
