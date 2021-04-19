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
    public class CreateModel : PageModel
    {
        private readonly IRepository<Product> _repository;
        private readonly IRepository<Customer> _repositoryCustomer;
        private readonly IRepository<Model> _repositoryModel;
        public Customer Customer { get; set; }
        [BindProperty]
        public Product Product { get; set; }

        public CreateModel(BoOlContext context)
        {
            _repository = new ProductRepository(context);
            _repositoryCustomer = new CustomerRepository(context);
            _repositoryModel = new ModelRepository(context);
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

            ViewData["ModelId"] = new SelectList(await _repositoryModel.SelectAsync(null), "Value", "Text");
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
