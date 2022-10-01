using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BoOl.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using BoOl.Repository;
using BoOl.Persistence.DatabaseContext;

namespace BoOl.Pages.Orders
{
    //створення замовлення через клієнта
    [Authorize(Roles = "Owner, Administrator")]
    public class CreateModel : PageModel
    {
        private readonly IRepository<Order> _repository;
        private readonly IRepository<Product> _repositoryProduct;
        private readonly IRepository<Customer> _repositoryCustomer;
        private readonly UserRepository _repositoryUser;

        [BindProperty]
        public Order Order { get; set; }
        [BindProperty]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public CreateModel(BoOlContext context)
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
            CustomerId = Convert.ToInt32(id);
            Order = new Order();
            Customer = await _repositoryCustomer.GetByIdAsync(CustomerId);
            Order.Discount = Customer.Discount;
            Order.DateOfAdmission = DateTime.Now.Date;
            ViewData["ProductId"] = new SelectList(await _repositoryProduct.SelectAsync(id), "Value", "Text");
            var user = await _repositoryUser.GetByIdAsync(User.Identity.Name);
            Order.WorkerId = Convert.ToInt32(user.WorkerId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Customer = await _repositoryCustomer.GetByIdAsync(CustomerId);
                ViewData["ProductId"] = new SelectList(await _repositoryProduct.SelectAsync(CustomerId), "Value", "Text");
                return Page();
            }

            await _repository.AddAsync(Order);

            return RedirectToPage("./Details", new { id = Order.Id});
        }
    }
}
