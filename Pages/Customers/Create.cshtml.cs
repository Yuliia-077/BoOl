using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BoOl.Models;
using BoOl.Repository;
using Microsoft.AspNetCore.Authorization;

namespace BoOl.Pages.Customers
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IRepository<Customer> _repository;

        [BindProperty]
        public Customer Customer { get; set; }

        public CreateModel(BoOlContext context)
        {
            _repository = new CustomerRepository(context);
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _repository.AddAsync(Customer);
            return RedirectToPage("./Index");
        }
    }
}
