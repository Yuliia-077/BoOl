using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;

namespace BoOl.Pages.CustomServices
{
    public class IndexModel : PageModel
    {
        private readonly BoOl.Models.BoOlContext _context;

        public IndexModel(BoOl.Models.BoOlContext context)
        {
            _context = context;
        }

        public IList<CustomService> CustomService { get;set; }

        public int Id { get; set; }

        public async Task OnGetAsync(int? id)
        {
            if(id!=null)
            {
                Id = Convert.ToInt32(id);
                CustomService = await _context.CustomServices
                .Include(c => c.Order)
                .Include(c => c.Part)
                .Include(c => c.Service)
                .Include(c => c.Worker)
                .Where(c => c.OrderId == id)
                .ToListAsync();

            }
        }
    }
}
