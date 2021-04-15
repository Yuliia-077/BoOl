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

namespace BoOl.Pages.Customers
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IRepository<Customer> _repository;

        [BindProperty]
        public Customer Customer { get; set; }

        public EditModel(BoOlContext context)
        {
            _repository = new CustomerRepository(context);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _repository.GetByIdAsync(Convert.ToInt32(id));

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.UpdateAsync(Customer);

            return RedirectToPage("./Index");
        }
    }
}
