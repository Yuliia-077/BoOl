using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Domain;
using BoOl.Repository;
using Microsoft.AspNetCore.Authorization;
using BoOl.Persistence.DatabaseContext;

namespace BoOl.Pages.Workers
{
    //перелік працівників поділених по посадах
    [Authorize(Roles = "Owner, Administrator")]
    public class IndexModel : PageModel
    {
        private readonly IRepository<Position> _repository;
        private readonly IRepository<Worker> _repositoryWorker;
        public IEnumerable<Position> Positions { get; set; }
        public int CountOfPosition { get; set; }
        public int CountOfWorkers { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchPosition { get; set; }

        public IndexModel(BoOlContext context)
        {
            _repository = new PositionRepository(context);
            _repositoryWorker = new WorkerRepository(context);
        }

        public async Task OnGetAsync()
        {
            var positions = await _repository.GetAllAsync(null);
            CountOfPosition = await _repository.CountAsync(null);
            foreach (var position in positions)
            {
                CountOfWorkers += position.Workers.Count();
            }
            if (!string.IsNullOrEmpty(SearchPosition))
            {
                positions = positions.Where(s => s.Name.Contains(SearchPosition));
            }
            Positions = positions.ToList();
        }

        public async Task<IActionResult> OnGetDelete(int? id)
        {
            await _repository.DeleteAsync(Convert.ToInt32(id));
            return RedirectToPage("./Index");
        }
    }
}
