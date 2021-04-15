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
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IRepository<Position> _repository;
        public IEnumerable<Position> Positions { get; set; }
        public int CountOfPosition { get; set; }
        public int CountOfWorkers { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchPosition { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public string SearchWorker { get; set; }

        public IndexModel(BoOlContext context)
        {
            _repository = new PositionRepository(context);
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
            //if(!string.IsNullOrEmpty(SearchWorker))
            //{

            //}

            Positions = positions.ToList();
        }
    }
}
