﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoOl.Models;

namespace BoOl.Pages.Storages
{
    public class IndexModel : PageModel
    {
        private readonly BoOl.Models.BoOlContext _context;

        public IndexModel(BoOl.Models.BoOlContext context)
        {
            _context = context;
        }

        public IList<Storage> Storage { get;set; }

        public async Task OnGetAsync()
        {
            Storage = await _context.Storages
                .Include(s => s.Model)
                .Include(s => s.Worker).ToListAsync();
        }
    }
}
