using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;
using Microsoft.AspNetCore.Authorization;
using BoOl.Repository;

namespace BoOl.Pages.Storages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IRepository<Storage> _repository;
        public int CountOfDeliveries { get; set; }
        public IEnumerable<Storage> Storage { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IndexModel(BoOlContext context)
        {
            _repository = new StorageRepository(context);
        }

        public async Task OnGetAsync()
        {
            CountOfDeliveries = await _repository.CountAsync(null);
            var deliveries = await _repository.GetAllAsync(null);
            if (!string.IsNullOrEmpty(SearchString))
            {
                deliveries = deliveries.Where(s => s.Name.Contains(SearchString));
            }

            Storage = deliveries.ToList();
        }
    }
}
