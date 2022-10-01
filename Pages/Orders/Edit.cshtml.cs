using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoOl.Domain;
using Microsoft.AspNetCore.Authorization;
using BoOl.Repository;
using BoOl.Persistence.DatabaseContext;

namespace BoOl.Pages.Orders
{
    //редагування замовлення
    [Authorize(Roles = "Owner, Administrator")]
    public class EditModel : PageModel
    {
        private readonly IRepository<Order> _repository;
        private readonly IRepository<Product> _repositoryProduct;
        private readonly IRepository<Customer> _repositoryCustomer;
        private readonly UserRepository _repositoryUser;

        [BindProperty]
        public Order Order { get; set; }
        [BindProperty]
        public int CustomerId { get; set; }


        public EditModel(BoOlContext context)
        {
            _repository = new OrderRepository(context);
            _repositoryProduct = new ProductRepository(context);
            _repositoryCustomer = new CustomerRepository(context);
            _repositoryUser = new UserRepository(context);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _repository.GetByIdAsync(Convert.ToInt32(id));
            CustomerId = Order.Product.CustomerId;

            if (Order == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(await _repositoryProduct.SelectAsync(CustomerId), "Value", "Text");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ProductId"] = new SelectList(await _repositoryProduct.SelectAsync(CustomerId), "Value", "Text");
                return Page();
            }

            await _repository.UpdateAsync(Order);
            return RedirectToPage("./Details", new {Order.Id});
        }
    }
}
