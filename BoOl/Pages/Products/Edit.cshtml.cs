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
    //редагувати техніку
    [Authorize(Roles = "Owner, Administrator")]
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IModelService _modelService;
        private readonly IProductValidation _productValidation;

        public EditModel(IProductService productService,
            IModelService modelService,
            IProductValidation productValidation)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _modelService = modelService ?? throw new ArgumentNullException(nameof(modelService));
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

            var item = await _productService.GetById(id.Value);

            if (item == null)
            {
                return NotFound();
            }

            Product = item.AsViewModel();
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

            await _productService.Update(dto);

            return RedirectToPage("./Details", new { id = Product.Id });
        }
    }
}
