using BoOl.Application.Services.Customers;
using BoOl.Models.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace BoOl.Pages.Customers
{
    //редагування клієнта
    [Authorize(Roles = "Owner, Administrator")]
    public class EditModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public EditModel(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound("Id не забезпечено.");
            }

            var dto = await _customerService.GetById(Convert.ToInt32(id));

            if (dto == null)
            {
                return NotFound($"Для даного Id = {id} користувача не існує.");
            }
            Customer = dto.AsViewModel();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _customerService.Update(Customer.AsDto());

            return RedirectToPage("./Details", new { id = Customer.Id});
        }
    }
}
