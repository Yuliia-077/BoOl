using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;
using BoOl.Repository;
using Microsoft.AspNetCore.Authorization;

namespace BoOl.Pages.Workers
{
    //повна інформація по працівнику
    [Authorize(Roles = "Owner, Administrator")]
    public class DetailsModel : PageModel
    {
        private readonly IRepository<Worker> _repository;
        public int CountOfOrders { get; set; }
        public int CountOfStorage { get; set; }
        public int CountOfServices { get; set; }

        public DetailsModel(BoOlContext context)
        {
            _repository = new WorkerRepository(context);
        }

        public Worker Worker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Worker = await _repository.GetByIdAsync(Convert.ToInt32(id));
            Worker.Orders = Worker.Orders.OrderByDescending(c => c.DateOfAdmission.Date).ToList();

            if (Worker == null)
            {
                return NotFound();
            }

            CountOfOrders = Worker.Orders.Count();
            CountOfServices = Worker.CustomServices.Count();
            CountOfStorage = Worker.Storages.Count();
            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToPage("./Index");
        }
    }
}
