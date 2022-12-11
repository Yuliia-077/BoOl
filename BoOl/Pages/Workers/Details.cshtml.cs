using BoOl.Application.Services.Workers;
using BoOl.Application.Validations.Workers;
using BoOl.Models.Workers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace BoOl.Pages.Workers
{
    //повна інформація по працівнику
    [Authorize(Roles = "Owner, Administrator")]
    public class DetailsModel : PageModel
    {
        private readonly IWorkerService _workerService;
        private readonly IWorkerValidation _workerValidation;
        private readonly int _pageSize = 6;

        public DetailsModel(IWorkerService workerService,
            IWorkerValidation workerValidation)
        {
            _workerService = workerService;
            _workerValidation = workerValidation;
        }

        public WorkerDetails Worker { get; set; }

        public int OrdersTotalPages { get; private set; }
        public int StoragesTotalPages { get; private set; }
        public int CustomServicesTotalPages { get; private set; }

        [BindProperty(SupportsGet = true)]
        public int OrdersCurrentPage { get; set; }
        [BindProperty(SupportsGet = true)]
        public int StoragesCurrentPage { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CustomServicesCurrentPage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await Get(id.Value);

            if (Worker == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var error = await _workerValidation.ValidationForDelete(id);

            if (error != null)
            {
                ModelState.AddModelError("Worker", error);
            }

            if (!ModelState.IsValid)
            {
                await Get(id);
                return Page();
            }

            await _workerService.Delete(id);

            return RedirectToPage("./Index");
        }

        private async Task Get(int id)
        {
            if (OrdersCurrentPage == default(int))
            {
                OrdersCurrentPage = 1;
            }

            if (StoragesCurrentPage == default(int))
            {
                StoragesCurrentPage = 1;
            }

            if (CustomServicesCurrentPage == default(int))
            {
                CustomServicesCurrentPage = 1;
            }

            var item = await _workerService.GetDetails(id, OrdersCurrentPage, StoragesCurrentPage, CustomServicesCurrentPage, _pageSize);

            StoragesTotalPages = (int)Math.Ceiling(decimal.Divide(item.CountOfStorages, _pageSize));
            OrdersTotalPages = (int)Math.Ceiling(decimal.Divide(item.CountOfOrders, _pageSize));
            CustomServicesTotalPages = (int)Math.Ceiling(decimal.Divide(item.CountOfCustomServices, _pageSize));

            Worker = item.AsViewModel();
        }
    }
}
