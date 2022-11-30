using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Domain;
using Microsoft.AspNetCore.Authorization;
using BoOl.Repository;
using BoOl.Persistence.DatabaseContext;

namespace BoOl.Pages.Orders
{
    //повна інформація по замовленню
    [Authorize(Roles = "Owner, Administrator, Technician")]
    public class DetailsModel : PageModel
    {
        private readonly IRepository<Order> _repository;
        public int CountOfServices { get; set; }

        [BindProperty]
        public Order Order { get; set; }

        public DetailsModel(BoOlContext context)
        {
            _repository = new OrderRepository(context);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _repository.GetByIdAsync(Convert.ToInt32(id));

            if (Order == null)
            {
                return NotFound();
            }
            CountOfServices = await _repository.CountAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToPage("./Index");
        }
    }
}
