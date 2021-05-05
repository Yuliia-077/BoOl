using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoOl.Models;
using BoOl.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BoOl.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRepository<Service> _repository;
        public IEnumerable<Service> Services { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IndexModel(ILogger<IndexModel> logger, BoOlContext context)
        {
            _logger = logger;
            _repository = new ServiceRepository(context);
        }

        public async Task OnGetAsync()
        {
            var services = await _repository.GetAllAsync(null);
            if (!string.IsNullOrEmpty(SearchString))
            {
                services = services.Where(s => s.Name.Contains(SearchString));
            }

            Services = services.ToList();
        }
    }
}
