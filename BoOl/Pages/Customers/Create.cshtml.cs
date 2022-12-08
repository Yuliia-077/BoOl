using BoOl.Application.Services.Customers;
using BoOl.Application.Validations.Customers;
using BoOl.Models.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace BoOl.Pages.Customers
{
    //створення нового клієнта
    [Authorize(Roles = "Owner, Administrator")]
    public class CreateModel : PageModel
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerValidation _customerValidation;
        public CreateModel(ICustomerService customerService,
            ICustomerValidation customerValidation)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _customerValidation = customerValidation ?? throw new ArgumentNullException(nameof(customerValidation));
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = Customer.AsDto();
            var error = await _customerValidation.ValidationForCreateOrUpdate(dto);

            if (error != null)
            {
                ModelState.AddModelError("Customer", error);
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var customerID = await _customerService.Create(dto);
            return RedirectToPage("./Details", new { id = customerID});
        }
    }
}
