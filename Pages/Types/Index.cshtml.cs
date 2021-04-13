using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;
using BoOl.Repository;

namespace BoOl.Pages.Types
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<Model> _repository;
        public IEnumerable<Model> Models { get; set; }
        public int CountOfModels { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IndexModel(BoOlContext context)
        {
            _repository = new ModelRepository(context);
        }

        public async Task OnGetAsync()
        {
            CountOfModels = await _repository.CountAsync(null);
            var models = await _repository.GetAllAsync(null);
            if (!string.IsNullOrEmpty(SearchString))
            {
                models = models.Where(s => s.Manufacturer.Contains(SearchString));
            }

            Models = models.ToList();
        }
    }
}
