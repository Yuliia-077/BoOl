using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;
using BoOl.Repository;
using Microsoft.AspNetCore.Authorization;

namespace BoOl.Pages.Products
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IRepository<Product> _repository;
        private readonly IRepository<Model> _repositoryModel;
        [BindProperty]
        public Product Product { get; set; }

        public EditModel(BoOlContext context)
        {
            _repository = new ProductRepository(context);
            _repositoryModel = new ModelRepository(context);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _repository.GetByIdAsync(Convert.ToInt32(id));

            if (Product == null)
            {
                return NotFound();
            }

            ViewData["ModelId"] = new SelectList(await _repositoryModel.SelectAsync(), "Value", "Text");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.UpdateAsync(Product);

            return RedirectToPage("./Details", new { id = Product.Id });
        }
    }
}
