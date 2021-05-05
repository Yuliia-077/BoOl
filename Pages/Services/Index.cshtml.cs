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

namespace BoOl.Pages.Services
{
    //перелік усіх послуг
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IRepository<Service> _repository;
        public IEnumerable<Service> Services { get; set; }
        public int CountOfServices { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IndexModel(BoOlContext context)
        {
            _repository = new ServiceRepository(context);
        }

        public async Task OnGetAsync()
        {
            CountOfServices = await _repository.CountAsync(null);
            var services = await _repository.GetAllAsync(null);
            if (!string.IsNullOrEmpty(SearchString))
            {
                services = services.Where(s => s.Name.Contains(SearchString));
            }

            Services = services.ToList();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToPage("./Index");
        }
    }
}
