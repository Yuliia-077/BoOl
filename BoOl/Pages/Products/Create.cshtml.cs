using BoOl.Application.Services.Customers;
using BoOl.Application.Services.Models;
using BoOl.Application.Services.Products;
using BoOl.Application.Validations.Products;
using BoOl.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace BoOl.Pages.Products
{
    //додати нову техніку до певного клієнта
    [Authorize(Roles = "Owner, Administrator")]
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IModelService _modelService;
        private readonly ICustomerService _customerService;
        private readonly IProductValidation _productValidation;

        public CreateModel(IProductService productService,
            IModelService modelService,
            ICustomerService customerService,
            IProductValidation productValidation)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _modelService = modelService ?? throw new ArgumentNullException(nameof(modelService));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _productValidation = productValidation ?? throw new ArgumentNullException(nameof(productValidation));
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = new Product();
            Product.CustomerName = await _customerService.GetName(id.Value);
            Product.CustomerId = id.Value;

            ViewData["ModelId"] = new SelectList(await _modelService.SelectListOfModelsAsync(), "Value", "Text");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = Product.AsDto();
            var error = await _productValidation.ValidationForCreateOrUpdate(dto);

            if (error != null)
            {
                ModelState.AddModelError("Product", error);
            }

            if (!ModelState.IsValid)
            {
                ViewData["ModelId"] = new SelectList(await _modelService.SelectListOfModelsAsync(), "Value", "Text");
                return Page();
            }

            var id = await _productService.Create(dto);

            return RedirectToPage("/Customers/Details", new { id = Product.CustomerId});
        }
    }
}
