using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BoOl.Models;
using Microsoft.AspNetCore.Authorization;
using BoOl.Repository;

namespace BoOl.Pages.CustomServices
{
    //створення послуги по замовленню
    [Authorize(Roles = "Owner, Technician")]
    public class CreateModel : PageModel
    {
        private readonly IRepository<CustomService> _repository;
        private readonly IRepository<Service> _repositoryService;
        private readonly UserRepository _repositoryUser;
        [BindProperty]
        public CustomService CustomService { get; set; }

        public CreateModel(BoOlContext context)
        {
            _repository = new CustomServiceRepository(context);
            _repositoryService = new ServiceRepository(context);
            _repositoryUser = new UserRepository(context);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {

                return NotFound();
            }
            CustomService = new CustomService();
            CustomService.OrderId = Convert.ToInt32(id);
            ViewData["ServiceId"] = new SelectList(await _repositoryService.SelectAsync(null), "Value", "Text");
            var user = await _repositoryUser.GetByIdAsync(User.Identity.Name);
            CustomService.WorkerId = Convert.ToInt32(user.WorkerId);
            CustomService.ExecutionDate = DateTime.Now.Date;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ServiceId"] = new SelectList(await _repositoryService.SelectAsync(null), "Value", "Text");
                return Page();
            }

            await _repository.AddAsync(CustomService);

            return RedirectToPage("./Details", new { id = CustomService.Id });
        }
    }
}
