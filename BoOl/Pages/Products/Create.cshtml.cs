using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoOl.Domain;
using BoOl.Repository;
using Microsoft.AspNetCore.Authorization;
using BoOl.Persistence.DatabaseContext;
using BoOl.Application.Services.Models;

namespace BoOl.Pages.Products
{
    //додати нову техніку до певного клієнта
    [Authorize(Roles = "Owner, Administrator")]
    public class CreateModel : PageModel
    {
        private readonly IRepository<Product> _repository;
        private readonly IRepository<Customer> _repositoryCustomer;
        private readonly IModelService _modelService;
        public Customer Customer { get; set; }
        [BindProperty]
        public Product Product { get; set; }

        public CreateModel(BoOlContext context,
            IModelService modelService)
        {
            _repository = new ProductRepository(context);
            _repositoryCustomer = new CustomerRepository(context);
            _modelService = modelService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = new Product();
            var customer = await _repositoryCustomer.GetByIdAsync(Convert.ToInt32(id));

            Product.Customer = customer;
            Product.CustomerId = customer.Id;

            ViewData["ModelId"] = new SelectList(await _modelService.SelectListOfModelsAsync(), "Value", "Text");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.AddAsync(Product);

            return RedirectToPage("/Customers/Details", new { id = Product.CustomerId});
        }
    }
}
