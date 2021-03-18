using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;

namespace BoOl.Pages.Position
{
    public class IndexModel : PageModel
    {
        private readonly BoOlContext _context;

        public IndexModel(BoOlContext context)
        {
            _context = context;
        }

        public IList<Models.Position> Position { get;set; }

        public async Task OnGetAsync()
        {
            Position = await _context.Positions.OrderBy(x=>x.Name).ToListAsync();
        }
    }
}
